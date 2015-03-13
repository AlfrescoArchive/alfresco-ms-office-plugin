**Note: This content was migrated from the Alfresco Wiki and may not be up to date.**

# Compatibility #

## Office 2003 ##
Since Version 2.1, Add-Ins have been available for Microsoft Word, Excel and PowerPoint 2003.

## Microsoft Office 2007 ##
Although the Alfresco Add-Ins have been designed with Microsoft Office 2003 in mind, they are compatible with Microsoft Office 2007, with the following caveats:

  * Before installing the Add-Ins, ensure the _.NET Programmability Support_ option has been installed for each of the Office applications you are installing the add-ins for. Normally these will be Word, Excel and PowerPoint.
    * The options can be found by running the Office Setup program and expanding the list of available options for each application.
    * You may need your original Office 2007 install media in order to add these essential components.

### An Important Note about Windows Vista ###
You are likely to be running Office 2007 on Windows Vista. Unfortunately, Microsoft have rewritten the WebDAV parts of Vista which means you will experience **READ ONLY** access to the Alfresco Repository over WebDAV. This is a known problem with Vista and effects many applications, [including Microsoft's own SharePoint Server](http://blogs.msdn.com/sharepoint/archive/2007/10/19/known-issue-office-2007-on-windows-vista-prompts-for-user-credentials-when-opening-documents-in-a-sharepoint-2007-site.aspx). There is no known workaround at the time of writing, despite the ones suggested in the linked article.

CIFS access is unaffected and works as it does with Windows XP. Therfore, you will have to use CIFS to obtain read/write access to Alfresco using Windows Vista.

# Installation #
**Note: the following example is for the Office 3-in-1 installer which installs all three add-ins. If you only want to install one or two of the three Office Applications, Individual installers are available.**

  * Unzip the zip file containing the setup files. You should have:
    * readme.rtf
    * setup.exe
    * AlfrescoOffice2003Setup.msi
    * Office2003PIA/o2003pia.msi
  * Ensure none of the Microsoft Office applications are running. Note you may have to also close down Outlook if you use Word as the e-mail editor.
  * Run setup.exe
    * You may need to have local administrative priviledges in order to install the Add-In. This is due to some system files (e.g. .NET 2.0 framework) which need updating.
  * If required, the setup program will download components it needs from the Microsoft web site. The required two components are the .NET 2.0 framework located at http://go.microsoft.com/fwlink/?LinkId=37283 and the Visual Studio 2005 Tools for Office Second Edition runtime located at http://go.microsoft.com/fwlink/?LinkId=79951
  * Once setup is complete and has exited, run the Office application (e.g. Word)

# Configuration #
The Add-Ins use a common configuration and present the configuration screen when none is found.
You can return to the configuration screen at any time via the link at the bottom of the Add-In window.

It is recommended that all configuration boxes are filled-in for the best user experience.

<img src='http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_Configuration.png' alt='Configuration Screen' height='550' />

## Web Client URL ##
(Mandatory) Enter the URL to Alfresco Explorer. This will usually take the form:
<pre>http://server:8080/alfresco/</pre>

## WebDAV URL ##
(Mandatory) This is usually the Web Client URL appended with _webdav/_, e.g.
<pre>http://server:8080/alfresco/webdav/</pre>

The Add-In will try to auto-complete this value when you start typing.

## CIFS Server ##
(Optional - unless using Windows Vista (see above)) Alfresco recommend using the CIFS interface to access your documents. As before, the Add-In will attempt to help by auto-completing this value, but check with your Alfresco administrator for the correct address. e.g.

<pre>\\servera\alfresco\</pre> or <pre>\\servera\alfresco\</pre> (v2.1 Enterprise and later)

## Authentication ##
The Add-In will always try to automatically log you in to Alfresco in order to present your checked-out documents, your assigned tasks, etc. If you are using the CIFS interface, authentication is automatic in most cases. However, sometimes the Add-In needs to present your Alfresco username and password in order to be correctly authenticated. It is recommeneded that you enter and save your Alfresco credentials. All values are stored in the Windows registry and your password is encrypted against unauthorized use.

# An important note about CIFS #
If you intend to use the CIFS interface to save documents via the add-in, it is very important that you are authenticated automatically. Limitations in the Microsoft Office APIs mean that an error is shown instead of an authentication dialog box if the Alfresco CIFS interface rejects your connection attempt. If you are not in an enterprise environment where it might not be possible to configure automatic authentication, mapping a network drive to the Alfresco CIFS interface should accomplish the same task.

# Using the Microsoft Office Add-In #
All the following examples are for the Word 2003 application. The Microsoft Add-In works similarly with Excel and PowerPoint.

Once configured, the Add-In starts and displays automatically when Word starts.

You can toggle the panel on and off using the Alfresco toolbar button displaying on the Word toolbar.

![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_ToolbarButton.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_ToolbarButton.png)

The main interface of the Add-In consists of five tabs:

![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/MSAddin-tabs.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/MSAddin-tabs.png)

  1. My Alfresco
  1. Browse Spaces
  1. Search
  1. Document Details
  1. Workflow
  1. Document Tags

Some tabs contain expandable panels, indicated by the ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_arrow_up.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_arrow_up.gif) icon. Click the icon to expand the panel and again to restore it.

## My Alfresco ##
The _My Alfresco_ tab is split into three sections:

<img src='http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_MyAlfresco.png' alt='Configuration Screen' height='550' />

### My Checked Out Documents ###
This tab displays all the documents and files you currently have checked out(Working Copies). Each file has up to three actions available:
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkin.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkin.gif) Check In: Check-in the working copy
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif) Start new workflow: Takes you to the Workflow tab to start workflow on the selected document
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_makepdf.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_makepdf.gif) Convert to PDF: Converts the document to Adobe PDF format
Additionally, you can click the file itself to open the document in Word (.doc files) or load the content via a new web browser window.

### My Tasks ###
This tab displays all tasks currently assigned to you, in ascending Due Date order. Overdue tasks are at the top of the list, followed by tasks due today, and so on.
  * Click a task to display the task details on the Workflow tab.

### Actions ###
Other actions available are:
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_create_space.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_create_space.gif) Create Collaboration Space: Takes you to the Browse Spaces tab with the Create Space panel displayed.
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_AlfrescoLogo16.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_AlfrescoLogo16.gif) Launch Alfresco: Launches the Alfresco Web Client in a new web browser window. **Note:** the Add-In uses Internet Explorer to render the user interface. When an external link is launched in a new browser window, it uses Internet Explorer even if you have a different default browser set in Windows.

Other actions may be available, depending on the current state of the Add-In.

## Browse Spaces ##
The _Browse Spaces_ tab is also split into three sections:

<img src='http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_Browse.png' alt='Browse Spaces Tab' height='550' />

### Current Space Navigator ###
The navigator shows the current space near the top of the panel. If you are not at the top-level Company Home space, there will also be an ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_go_up.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_go_up.gif) _Up_ icon to navigate to parent spaces.

Below the Current Space area are the subspaces contained within the current space, and then a list of all documents and files contained within the current space. Clicking these will navigate into that space and make it the current one.

Use the following functions on this tab to browse the spaces:
  * Click the ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_go_up.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_go_up.gif) _Up_ icon in the Current Space pane to navigate up one level to the parent space.
  * Click the ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/MSAddin-display-userhome.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/MSAddin-display-userhome.png) _Display User Home_ icon in the Current Space pane to navigate to the User Home space.
  * Click a subspace to make it the current space.
  * Clicking an item in the Documents list either opens the document in Word (.doc files) or loads the content in a new browser window.

At the top of the subspaces panel is a ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_create_space.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_create_space.gif) _Create New Space..._ item. Clicking this will drop down a form which allows you create new spaces.

![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_CreateSpace.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_CreateSpace.png)

### Documents and Files ###
Displays a complete list of all documents and files within the current space. Each file has certain actions available depending on the file type and the status of the file:
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkin.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkin.gif) Check In: Check-in the working copy
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkout.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkout.gif) Check Out: Check-out the document or file into the current space
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_lock.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_lock.gif) Locked: Neither check-in nor check-out is available
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif) Start new workflow: Takes you to the Workflow tab to start workflow on the selected document
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_makepdf.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_makepdf.gif) Convert to PDF: Converts the document to Adobe PDF format
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_delete.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_delete.gif) Delete: Deletes the document or file
Additionally, clicking the filename itself will either open the document in Word (.doc files) or load the content via a new web browser window.

### Uploading a Document to a Space ###
Upload a saved Word document to any space in the Alfresco repository by:
  * In Word, create and save a document.
  * On the _Browse Spaces_ and _Documents_ tab of the Alfresco panel, navigate to the space in which you want to store the document. The document will be saved to the space listed in the Current Space pane at the top of the panel.
  * Click ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_save_to_alfresco.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_save_to_alfresco.gif) _Save to Alfresco_ in the _Actions_ list. The document will be saved to the current space. If the document has not been given a filename yet, a popup panel will prompt you for one.
  * The Document Details tab displays the details of the uploaded document.

### Checking out a Document ###
When editing content, you can check out a content item to prevent other users from overwriting your work. Checking out content locks the original file and creates a working copy in the same space for you to work with.

  * Open Microsoft Office. The Alfresco Microsoft Add-In panel displays.
  * On the Browse Spaces and Documents tab of the Alfresco panel, navigate to the document you want to check out.
  * Select ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkout.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkout.gif) _Check Out_ icon associated with the document you want to modify.
  * The original document locks and the working copy becomes available to modify in both the Browse Spaces and Documents tab and the My Alfresco tab. The icon ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_lock.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_lock.gif) _Lock_ beside the original document indicates it is locked.

### Modifying Documents ###
You edit both checked in and checked out repository documents in the same way.

  * On the My Alfresco tab or the Browse Spaces and Documents tab of the Alfresco panel, click the document you want to edit to open it.
  * The document displays in Word and the Alfresco panel displays the Document Details tab listing the document metadata.
  * Modify the document in Word as necessary.
  * Save and close the file.

If you were editing a working copy, you can now check it in if no further work is required.

### Viewing Document Details ###
The _Document Details_ tab displays information on the document currently open in Word. The information available includes the document metadata, tags associated with the document, and the version history.

  * On the Browse Spaces and Documents tab of the Alfresco panel, navigate to the document containing the details you want to view.
  * Click the document to open it. The document displays in Word and the Alfresco panel displays the Document Details tab listing the document metadata.
  * Optionally, to view your document details in Explorer, click _Open Full Details_ in the _Document Actions_ list. You will need to log in to Alfresco Explorer, if prompted. The _Details_ page for the selected document displays in a new browser window.

### Tagging a Document ###
Create tags to categorize your document content. This enables you to easily locate the content again.

  * Open the document you want to tag. You can select a document on the My Alfresco tab or the Browse Spaces and Documents tab of the Alfresco panel. The document displays in Word and the panel displays the Document Details tab listing the document metadata.
  * Click _Add a tag_ on the Document Tags tab in the middle of the panel.
  * Type the name of the tag you want to add and click ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/MSAddin-addtag.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/MSAddin-addtag.png) _Add Tag_ to save and display it.
  * Click <pre>[x]</pre> to the left of a tag to delete it.

### Making a Document Versionable ###
Enable versioning for a document to track the revisions made to it.

  * Open the document you want to make versionable.
  * You can select a document on the My Alfresco tab or the Browse Spaces and Documents tab of the Alfresco panel.
  * The document displays in Word and the panel displays the Document Details tab listing the document metadata.
  * Click the Version History tab in the middle of the current panel.
  * Click _Make Versionable_ to enable versioning for the document.

### Checking in a Document ###
Once you complete your edits on a checked out document, you must check in the working copy to update the original in the repository.

  * In the _My Checked Out Documents_ list on the My Alfresco tab of the Alfresco panel, locate the file you want to check in. This action is also available in the _Documents_ list on the Browse Spaces and Documents tab.
  * Click ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkin.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkin.gif) _Check In_ for the document of interest. The document is checked in and removed from the _My Checked Out Documents_ list on this tab.

### Transforming a Document to PDF ###
You can easily transform a Word document in the Alfresco repository into Adobe PDF format.

  * On the Browse Spaces and Documents tab of the Alfresco panel, navigate to the document you want to transform. You can also perform this action on the My Alfresco and Document Details tabs.
  * Click ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_makepdf.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_makepdf.gif) _Transform to PDF_ associated with the document you want to transform. The PDF version of the document is created and added to the same space as the original document.

### Inserting a File into the Current Document ###
Use the _Insert File_ action to insert the contents of a Word document from the repository directly into the currently open Word document.

  * Open the Word document you want to work with. This can be a document from the repository or any document on your computer.
  * Place the cursor in the open document at the position you want to insert the content.
  * On the Browse Spaces and Documents tab of the Alfresco panel, navigate to the document whose contents you want to insert into the open document. You can also perform this action on the My Alfresco tab.
  * Click ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/MSAddin-insertcontent.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/MSAddin-insertcontent.png) _Insert File into Current Document_. The contents of the selected document are inserted at the current cursor position in your open Word document.

### Starting a New Workflow Against a Document ###
Use the workflow feature to attach workflow directly to a document and then assign the document to another user for review. Two preconfigured workflows are available: Adhoc Task (for assigning a task to a colleague) and Review & Approve (for setting up review and approval of content). The workflow tasks are managed on the My Tasks tab.

  * On the Browse Spaces and Documents tab of the Alfresco panel, navigate to the document against which you want to start a workflow. You can also perform this action on the My Alfresco and Document Details tabs.
  * Click ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif) _Start Workflow_ for the document of interest. The _My Tasks_ tab displays with the _Start Workflow_ view.
  * Select the Workflow type as _Review & Approve_ or _Adhoc Task_ from the list provided.
  * Assign an Alfresco user to the workflow. Type the full or partial name and then select the desired user from the list of matches found.
  * Optionally, click the empty field and select the due date for the task from the drop-down calendar.
  * Type a description for the task.
  * Click _Submit_ to start the new workflow. The _My Tasks_ tab displays the new workflow task for the user against whom you assigned the task.

### Deleting a Document ###
Delete a document to permanently remove it from the repository.

  * On the Browse Spaces and Documents tab of the Alfresco panel, navigate to the document you want to delete. **You cannot delete the working copy of a document.**
  * Select ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_delete.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_delete.gif) _Delete_ associated with the document you want to remove.
  * Click _OK_ when prompted to confirm the deletion. The document is deleted from the repository and removed from the document list.

### Managing Your Document Tasks ###
Use the My Tasks tab to view and manage the tasks assigned to you.

  * Click the My Tasks tab on the Alfresco panel to view all tasks currently assigned to you, in ascending due date order. Overdue tasks are at the top of the list, followed by tasks due today, and so on.
  * Select the task you want to manage. The bottom portion of the tab displays the task's status, priority, start date, type, and complete percentage, as well as the action you are required to take for the task.
  * Optionally, click the document to open it, either in a new web browser window or in Word.
  * Complete the action required for the task. The task actions available depend on the type of task and current state of that task. For example, a _Review & Approve_ task will have _Reject_ and _Approve_ actions.
  * Optionally, to display the task in more detail in Alfresco Explorer, click _Manage_. You will need to log in to Explorer, if prompted. The details for the selected task display in a new browser window.

### Viewing Document Tags ###
Viewing tags enables you to filter the repository contents to make locating specific documents more manageable.

  * Click the Document Tags tab on the Alfresco panel to view all of the tags associated with the documents in Alfresco.
  * In the _Tag Cloud_ pane, click a tag to display all documents and files associated with the tag.
  * In the list returned, click any displayed document to open it.

## Search ##
You can search for spaces and files using the simple search panel.

<img src='http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_Search.png' alt='Browse Spaces Tab' height='550' />

  * On the Search Alfresco tab of the Alfresco panel, type your query in the _Search for_ box.
  * Select the maximum number items you want displayed using the drop-down box.
  * Click _Search_. If more results were found in the repository than are being displayed, a message similar to _Showing first 5 of 13 total items found_ is shown. If all results are being displayed, the message will be of the form _Showing all 13 items found_.

In the results list:
  * Clicking a space will display that space in the Browse Spaces and Documents tab.
  * Clicking a Word document will open the document in Microsoft Word
  * Clicking any other type of file will launch that file with a new web browser window

## Document Details ##
The _Document Details_ tab has three main sections:

<img src='http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_DocumentDetails.png' alt='Document Details Tab' height='550' />


### Current Document Details ###
If the document you are currently working on is recognised as being stored in the Alfresco repository, the Document Details tab will be populated.
  * A ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_lock.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_lock.gif) icon indicates that the document is currently locked - i.e. cannot be checked in or out. This usually indicates you should be editing the Working Copy instead.

### Version History ###
If the document has a version history, this will be shown in the middle panel.
  * You can apply the versionable aspect to any document by clicking the ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_make_versionable.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_make_versionable.gif) _Make Versionable_ icon

### Actions ###
Certain Document Actions will be available depending on the current document:
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkin.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkin.gif) Check In: Check-in the working copy
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkout.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_checkout.gif) Check Out: Check-out the document or file into the current space
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif) Start Workflow: Takes you to the Workflow tab to start workflow on the current document
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_makepdf.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_makepdf.gif) Transform to PDF: Converts the current document to Adobe PDF format
  * ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_document_details.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_document_details.gif) Open Full Details: Opens a new web browser window showing the details dialog in the Alfresco Web Client UI.

## Workflow ##
This panel works in two modes, depending on whether you are viewing an existing task, or starting a new workflow on an existing document. In each mode a list of tasks assigned to you appears at the top of the panel, displayed in ascending Due Date order - overdue tasks will be at the top of the list, followed by tasks due today, and so on. Clicking a task will display the task details view in the bottom panel.

<img src='http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_TaskDetails.png' alt='Workflow Spaces Tab' height='550' />


### Task Detail view ###
Shows the task's Status, Priority, Start Date, Type and Complete percentage, as well as a list of resources associated with the task.
  * Clicking on a document in the list of resources will open that document, either in a new web browser window or the Word Application

Task Actions appear under the resource list and are dependant on the type of task and current state of that task.
  * For example, a Review & Approve task will have _Reject_ and _Approve_ actions buttons available.

### Start New Workflow view ###
When the ![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_new_workflow.gif) _Start Workflow_ action is run against a document, the bottom panel changes to the start workflow view:

![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_StartWorkflow.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_StartWorkflow.png)
  * Workflow type can be "Review & Approve" or "Adhoc Task" only
  * Assign to is the Alfresco user who you want to assign the new workflow to. An autocomplete drop-down will help you fill the box after you type the first two characters of the user's name:

![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_StartWorkflow-pick_user.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_StartWorkflow-pick_user.png)
  * Due on is an optional date by which the task is due. Clicking in the empty field will display a date picker drop-down:
![http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_StartWorkflow-pick_date.png](http://wiki.alfresco-ms-office-plugin.googlecode.com/hg/images/Word2003_StartWorkflow-pick_date.png)
  * Description is how the task will appear in the My Tasks panels
  * Finally, Submit the form to start the new workflow


### Document Tags ###

The Document Tags tab displays all tags associated with documents in Alfresco. You can then view a list of documents associated with a specific tag.