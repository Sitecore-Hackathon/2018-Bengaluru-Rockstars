# Documentation
![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# XConnect Rocks - Bengluru Rockstars

Welcome to Sitecore Hackathon 2018 - Submission by Bengluru Rockstars.

The Hackathon site can be found at http://www.sitecorehackathon.org/sitecore-hackathon-2018/

Bengluru Rockstars submission on XConnect category -  We are  Team from sapient Jisha Muthuswamy , AJi Viswantha, Deendayal



##Problem Statement
Currently there is no option available in sitecore to track offline email communications and we have created a app to scan the local emails available on local outlook inbox and based on the content of emails interaction are tracked across identified contacts. record important interactions in xDB. 

## Solution 
This is a console application which we have created to showcase omni-channel capabilities of xConnect, this is mainly for tracking the offline email communication happening with marketing team\call center agents. Most of us will be having outlook at our machines runs and we are utilizing that to get offline interactions. This console application runs at local machine and scans unread email sand the content will be processed against natural processing language API LUIS and recognize important transactions.   This application reads markets’ inbox and notify users about unread transactions happening, we have set up a dashboard on sitecore content editor and user will be able to see the current day reports there, like users who initiated goals & their email subject. The real catch in the implementation is that the mails will be placed I to LIUS queue only if that sender email id is a valid/identified visitor on the site.  This app reads unread emails from marketer’s local inbox and scan the email content. This email content will be passed to LUIS to identify the intent type, once intent has been identified the corresponding goal will be fetched from sitecore and that will be triggered against that identified contact. 

Package is uploaded at 

https://github.com/Sitecore-Hackathon/2018-Bengaluru-Rockstars/blob/master/sc.package/Sitecore%20Hacathon-2018-Bangalore%20Rockers-Sitecore-.zip

Getting Started
•	Download the Solution and Sitecore Package 
•	Dropbox URL : https://lion.app.box.com/folder/46277246138
•	Install a vanilla Sitecore 9.2 Version 2 instance on system
•	Setup the publish profile and publish the solution (Default publish profile is pointing to C:\inetpub\wwwroot\hackathon\Website)
•	Replace the connection string file
•	Install the package on sitecore which will install a template and related item in the master database and core database

#Getting Started
Install sitecore 9 instance
•	Download the Solution and Sitecore Package 
•	Dropbox URL : https://lion.app.box.com/folder/46277246138
•	Install a vanilla Sitecore 9.0 Update 1 Module (Module install package) instance on system
•	Install sitecore 
•	Replace the connection string file
•	Install the package on sitecore which will install a template and related item in the master database and core database

Setup XConnect Rocks 
Install XConnect Rocks 
•	Build the solution Hackathon.XConnectRocks and start the windows Application.
•	Modify App.config file available under the path “” and set the LUIS App keys and  other certificate information for the xconnect application. This console utilizes Sitecore Cognitive Service Ole Chat library for making connection to LIS and getting responses. 
•	

<add key="CognitiveService.OleChat.LUISAppUrl" value="https://westus.api.cognitive.microsoft.com/luis/v2.0/apps" />
    <add key="CognitiveService.OleChat.OleAppId" value="4590b630-2880-45e9-9dd1-13bdcc7b0093" />
    <add key="CognitiveService.OleChat.OleAppkey" value="13a3cf2af855495fbefe916a24de362e" />
    <add key="xConnectCertificate" value="StoreName=My;StoreLocation=LocalMachine;FindType=FindByThumbprint;FindValue=9EE7C4BA97D87E31F0300F2E1EAEC7E0BD7CC144" />
    <add key="xConnectClient" value="https://xp091.xconnect/" />
    <add key="APIToTriggerGoals" value="https://xp091.xconnect/" />
 

•	 Run console application "XConnectRocks/Hackathon.XConnectRocks" to scan emails available on local outlook. The assumption made is that that the outlook is already running on the local machine. 
 
PreRequistite: Outlook 2016 is running on the local machine and the dll referenced in the application Xconnect Rocks



The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

Examples of things to include are the following.

## Summary

**Category:** 

XConnect

xConnect is the service layer that sits in between the xDB and any trusted client, device, or interface that wants to read, write, or search xDB data.

 Currently there is no option available in sitecore to track offline email communications and we have created a app to scan the local emails available on local outlook inbox and based on the content of emails interaction are tracked across identified contacts. record important interactions in xDB. 

## Pre-requisites

 
PreRequistite: Outlook 2016 is running on the local machine and the dll referenced in the application Xconnect Rocks


- List any dependencies
- Or other modules that must be installed
- Or services that must be enabled/configured

## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

Install sitecore 9 instance
•	Download the Solution and Sitecore Package 
•	Dropbox URL : https://lion.app.box.com/folder/46277246138
•	Install a vanilla Sitecore 9.0 Update 1 Module (Module install package) instance on system
•	Install sitecore 
•	Replace the connection string file
•	Install the package on sitecore which will install a template and related item in the master database and core database

Setup XConnect Rocks 
Install XConnect Rocks 
•	Build the solution Hackathon.XConnectRocks and start the windows Application.
•	Modify App.config file available under the path “” and set the LUIS App keys and  other certificate information for the xconnect application. This console utilizes Sitecore Cognitive Service Ole Chat library for making connection to LIS and getting responses. 
•	

<add key="CognitiveService.OleChat.LUISAppUrl" value="https://westus.api.cognitive.microsoft.com/luis/v2.0/apps" />
    <add key="CognitiveService.OleChat.OleAppId" value="" />
    <add key="CognitiveService.OleChat.OleAppkey" value="" />
    <add key="xConnectCertificate" value="StoreName=My;StoreLocation=LocalMachine;FindType=FindByThumbprint;FindValue=" />
    <add key="xConnectClient" value="https://xp091.xconnect/" />
    <add key="APIToTriggerGoals" value="https://xp091.xconnect/" />


•	 Click the button “Rescan Email” to scan emails available on local outlook. The assumption made is that that the outlook is already running on the local machine. 


## Configuration

How do you configure your module once it is installed? Are there items that need to be updated with settings, or maybe config files need to have keys updated?

Remember you are using Markdown, you can provide code samples too:

```xml
<?xml version="1.0"?>
<!--
  Purpose: Configuration settings for my hackathon module
-->
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <settings>
      <setting name="MyModule.Setting" value="Hackathon" />
    </settings>
  </sitecore>
</configuration>
```

## Usage

Sitecore Hackathon 2018

Implementation Guide - XConnect Rocks 








Team Name: Bengaluru Rockstars Team
Member 1 : Aji Viswanadhan 
Member 2 :  Deendayal Sundaria S
Member 3 : Jisha Muthuswamy
Implemntation Document for XConnect Rocks
Problem Statement/Use case: 
Currently there is no option available in sitecore to track offline email communications and we have created a app to scan the local emails available on local outlook inbox and based on the content of emails interaction are tracked across identified contacts. record important interactions in xDB. 
Solution:
 
This is a console application which we have created to showcase omni-channel capabilities of xConnect, this is mainly for tracking the offline email communication happening with marketing team\call center agents. Most of us will be having outlook at our machines runs and we are utilizing that to get offline interactions. This console application runs at local machine and scans unread email sand the content will be processed against natural processing language API LUIS and recognize important transactions.   This application reads markets’ inbox and notify users about unread transactions happening, we have set up a dashboard on sitecore content editor and user will be able to see the current day reports there, like users who initiated goals & their email subject. The real catch in the implementation is that the mails will be placed I to LIUS queue only if that sender email id is a valid/identified visitor on the site.  This app reads unread emails from marketer’s local inbox and scan the email content. This email content will be passed to LUIS to identify the intent type, once intent has been identified the corresponding goal will be fetched from sitecore and that will be triggered against that identified contact. 
 























Initial Setup at LUIS, goals has been set up as Intendeds, and usual questionnaire as utterances.
Intents has been created at LUIS to determine goals and its associated with entities. This will be save to XDB while triggering the goals and same can be used later.
 
 

 


Intent Goals mapping in local.
  

 
Final Dashboard where marketers can team can get their offline interaction reports.
 


![Random](https://placeimg.com/480/240/any "Random")

## Video
 Video Url can be found here 
https://youtu.be/M9Dv13-Kg_8

