using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LIMS.Infrastructure.Identity;
using LIMS.Infrastructure.Services;
using LIMS.Infrastructure.Services.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace LIMS.WebApp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IMemoryCache _cache;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
             IMemoryCache cache)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cache = cache;
        }

        public string Username { get; set; }

		public string FirstName { get; set; }
		public string Middlename { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile Photo { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

			[Display(Name = "First Name")]
			public string FirstName { get; set; }

			[Display(Name = "Middle Name")]
			public string Middlename { get; set; }

			[Display(Name = "Last Name")]
			public string LastName { get; set; }

			[Display(Name = "KRA PIN")]
			public string KRAPIN { get; set; }

			[Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name ="Upload New Profile Picture")]
            public IFormFile Photo { get; set; }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Username = user.UserName;

            Input = new InputModel
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
				KRAPIN = user.KRAPIN,
				FirstName = user.FirstName,
				Middlename = user.MiddleName,
				LastName = user.LastName
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (Input.Email != user.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

			if (Input.FirstName != user.FirstName)
			{
				user.FirstName = Input.FirstName;
				var updateFirstName = await _userManager.UpdateAsync(user);
				if (!updateFirstName.Succeeded)
				{
					throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
				}
			}

			if (Input.Middlename != user.MiddleName)
			{
				user.MiddleName = Input.Middlename;
				var updateMiddleName = await _userManager.UpdateAsync(user);
				if (!updateMiddleName.Succeeded)
				{
					throw new InvalidOperationException($"Unexpected error occurred updating Middle Name for user with ID '{user.Id}'.");
				}
			}

			if (Input.LastName != user.LastName)
			{
				user.LastName = Input.LastName;

				var updateuser = await _userManager.UpdateAsync(user);
				if (!updateuser.Succeeded)
				{
					throw new InvalidOperationException($"Unexpected error occurred updating Last Name for user with ID '{user.Id}'.");
				}
			}

			if (Input.KRAPIN != user.KRAPIN)
			{
				user.KRAPIN = Input.KRAPIN;

				var updatekrapin =  await _userManager.UpdateAsync(user);

				if (!updatekrapin.Succeeded)
				{
					throw new InvalidOperationException($"Unexpected error occurred while updating KRA PIN for user with ID '{user.Id}'.");
				}
			}

			if (Input.PhoneNumber != user.PhoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }


            // Convert the user uploaded Photo as Byte Array before save to DB
            var Image = Input.Photo;
			if(Image != null)
			{
				if (Image.Length > 0)
				{
					using (var filestream = Image.OpenReadStream())
					using (var memorystream = new MemoryStream())
					{
						await filestream.CopyToAsync(memorystream);
						var UserPhoto = memorystream.ToArray();

						user.Photo = UserPhoto;
						try
						{
							user.Photo = DbImageAPI.Imaging.ScaleImage(memorystream.ToArray(), 50, 50, System.Drawing.Imaging.ImageFormat.Png);
							await _userManager.UpdateAsync(user);
							_cache.Set(user.Id, user.Photo);
						}
						catch
						{
						}
					}
				}
			}
          

            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "account/confirmed-email",
                pageHandler: null,
                values: new { user.Id, code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                user.Email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
