# Documentation

The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

Examples of things to include are the following.

## Summary

**Category:** Hackathon Category

What is the purpose of your module? What problem does it solve and how does it do that?

## Pre-requisites

Does your module rely on other Sitecore modules or frameworks?

- List any dependencies
- Or other modules that must be installed
- Or services that must be enabled/configured

## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

1. Use the Sitecore Installation wizard to install the [package](#link-to-package)
2. ???
3. Profit

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

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
