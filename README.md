# LIMS

Application review site https://demo.osl.co.ke:7574
## Land Information Management System
This project is about a unified land Information Management web and mobile portal. Land Administrators, organizations and
citizens will have roles and functions in the system. All users are authenticated and authorized. The following modules are 
available:
* Documents Management Module:

   Provides the document management functionality for managing the growing volumes of enterprise documents involved in NNLIMS. These documents include, but are not limited to, the Deed Plan, RIM, development applications, Local authority minutes, tittle Deeds and other required artefacts produced by the various actors in the respective business process. Through this module, the Ministry, county governments and other main stakeholders involved in this project will be able to efficiently and effectively manage the documentation. This includes ensuring that versions of documents from each stage of their life cycle can be retained for reference or legal reasons. NNLIMS will support high-capacity document storage. It is customized to define large-scale content management solutions that scale out to the requirements of the stakeholders. The users of the system will have a high Performance environment within which they can store documents for other sub-systems in the solution.
   
* Land Parcel Module:

   Facilitates the storage and use of the spatial i.e. GIS and cadastral data. This data is stored held in the spatial database that centrally manages the data with improved security & integrity as well as delivering access and editing capabilities to many users. The data contains parcel data (lot data) and other GIS contextual information. This spatial database will be populated from legacy sources (existing sources) as well as data migration efforts, which falls within the scope of this project. 
   
* Land Registry Module:

   Allows the linking of land objects (cadastral data, which is the parcel/lot data) with registration information (i.e. rights to land). All the relevant information pertaining to the ownership and status of a parcel is stored and obtained through this module. The module also provides the security component that manages permissions allowed to data regarding ownership. Therefore, only authorized users will have access to the ownership information.
* Business Workflow Automation Module:

   Allows the automation of the workflows through the implementation of development control module, spatial planning and land parcel module. These workflows are instantiated in correlation to these other interdependent modules, giving users a complete and comprehensive overview of the system. 
   
* Revenue Management Module:

   Manages the receipts for land rates for a particular parcel/lot in the county government. This happens in various stages of the respective workflows as documented in the business workflow automation module. The owners of the parcels are then required to pay for services provided by the county government. They are also required to pay rates and taxes. This module allows the county government, NLC, Ministry and other key stakeholders to manage payments for these rates and taxes including invoice and bill generation, statements generation, cash receipts and viewing of reports relating to these financial transactions.
   
* Viewer Module:

   Is the sub-system that manages all the user interface views. Since the data comes from various sources, the Viewer sub-system consolidates all the information in various user interface that allow the users to interact with the data. 
   
* Messaging Module:

   Is a sub-system that allows for communication between the various users of the system. Considering the various notifications, messages and information that has to be shared between the users, this component provides the required functionality for various users.
   
* Business Intelligence Module:

   Is the sub-system that allows for generation of the various required reports from the system.
## Database Model

![LIMS database model](https://github.com/ayiemba/LIMSPortal/blob/dev/Docs/LIMDbModel.png)

