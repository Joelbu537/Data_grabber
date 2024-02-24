# Data_grabber
## DISCLAIMER: This program is for educational purpose only, only use it on devices you own/have permission to use it on!
Grabs hostname, device name and IP and sends the collected data to a Discord webhook
### The grabber consists of 2 programms:
The grabber itself:
    Grabs data and sends it to a Discord webhook or whatever you want!
The so-called "background-process":
    Initialises the grabber, this step is required to disguise the grabber as a background process.
    Instead of the grabber having a console window open for 5 seconds which can be used to kill it before sending the data,
    you can only see a console window for 1 frame that immediately closes. Your "targets" won't be able to stop the grabber in that short time,
    and finding the right process via task-manager takes too long!
