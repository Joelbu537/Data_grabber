# Data_grabber
## DISCLAIMER: This program is for educational purpose only, only use it on devices you own/have permission to use it on!
Grabs hostname, device name and IP and sends the collected data to a Discord webhook
## Requirements
- Windows 7 or higher
- Both files in the same folder
- Working internet conenction while executing(should be obvious)
-  A discord webhook to receive the data
## Usage
> [!CAUTION]
> Firewalls are most likely going to block the open port/ask the user for permission!
> I am working on it, but have no idea on what to do:)
> So unless you have admin permissions on the target machine, you can only collect the information!
1. Execute the background.exe on the target device (Its going to start the actual grabber)
2. Check your Discord Webhook, you should see a message containing lots of informations!
3. Use TCP Message Sender and connect to the IP:PORT from the webhook.
> [!IMPORTANT]
> The Bot does not collect IPv6 adresses, update comming soon™!
> Make sure you are in the same LAN
4. Send a command to the device if you want. Confirm with y.
## Commands
- shutdown   Shuts down the target. Thats it
- http <parameter>   (Is going to be renamed to p) Starts a new process with the given parameters.

This can be used to open websites (http https://www.website.com/),
run executables, (http C:\Windows\Folder1\executable.exe) or open applications(http notepad)
