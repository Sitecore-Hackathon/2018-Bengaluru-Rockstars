![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# XConnect Rocks - Bengluru Rockstars

Welcome to Sitecore Hackathon 2018 - Submission by Bengluru Rockstars.

The Hackathon site can be found at http://www.sitecorehackathon.org/sitecore-hackathon-2018/

Bengluru Rockstars submission on XConnect category -  We are  Team from sapient Jisha Muthuswamy , AJi Viswantha, Deendayal



##Problem Statement
Currently there is no option available in sitecore to track offline email communications and we have created a app to scan the local emails available on local outlook inbox and based on the content of emails interaction are tracked across identified contacts. record important interactions in xDB. 

## Solution 
This is a console application which we have created to showcase omni-channel capabilities of xConnect, this is mainly for tracking the offline email communication happening with marketing team\call center agents. Most of us will be having outlook at our machines runs and we are utilizing that to get offline interactions. This console application runs at local machine and scans unread email sand the content will be processed against natural processing language API LUIS and recognize important transactions.   This application reads markets’ inbox and notify users about unread transactions happening, we have set up a dashboard on sitecore content editor and user will be able to see the current day reports there, like users who initiated goals & their email subject. The real catch in the implementation is that the mails will be placed I to LIUS queue only if that sender email id is a valid/identified visitor on the site.  This app reads unread emails from marketer’s local inbox and scan the email content. This email content will be passed to LUIS to identify the intent type, once intent has been identified the corresponding goal will be fetched from sitecore and that will be triggered against that identified contact. 

All teams are required to submit the following as part of their entry submission on or before the end of the Hackathon on **Saturday March 3rd 2018 at 8PM EST**. The modules should be based on [Sitecore 9.0 rev. 171219 (Update-1)](https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform/90/Sitecore_Experience_Platform_90_Update1.aspx).

**Failure to meet any of the requirements will result in automatic disqualification.** Please reach out to any of the organisers or judges if you require any clarification.

- Sitecore 9.0 Update 1 Module (Module install package)
   - An installation Sitecore Package (`.zip` or `.update`)

- Module code in a public Git source repository. We will be judging (amongst other things):
  - Cleanliness of code
  - Commenting where necessary
  - Code Structure
  - Standard coding standards & naming conventions

- Precise and Clear Installation Instructions document (1 – 2 pages)
- Module usage documentation on [Readme.md](documentation) file on the Git Repository (2 – 5 pages)
  - Module Purpose
  - Module Sitecore Hackathon Category
  - How does the end user use the Module?
  - Screenshots, etc.

- Create a 2 – 10 minutes video explaining the module’s functionality (A link to youtube video)

  - What problem was solved
  - How did you solve it
  - What is the end result
