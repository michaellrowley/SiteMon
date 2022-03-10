
# SiteMon

SiteMon is a tool that allows users to monitor specific webpages for minor/major changes based on a set of rules.

<center>

![Github Issues](https://img.shields.io/github/issues/michaellrowley/SiteMon) ![Github Forks](https://img.shields.io/github/forks/michaellrowley/SiteMon) ![Github Stars](https://img.shields.io/github/stars/michaellrowley/SiteMon) ![Repository License](https://img.shields.io/github/license/michaellrowley/SiteMon)

</center>

<center>
<img style="height: 250px;border:dotted #cccccc 2px;" src="https://i.ibb.co/ZHNpvBp/SITEMON-CONFIGURATION.png"/><br>
</center>

## Configuring SiteMon
### Notifications

*SiteMon notifications can be interpreted/logged in four ways:*

- **Popup window:**
	A (very basic) popup window will be shown in order to alert the user that a change has been detected.
- **Open URL:**
	The URL that a change has been detected in will be opened using the user's default web browser.
- **Alert sound:**
	The generic windows error sound will be played when a change is detected.
- **Message-box:**
	Similar in nature to the 'Popup window' option, a standard .NET message-box will be displayed, notifying the user that a change has been detected.

### IO

*This section concerns itself with the input/output section of the program (file writing/reading/encrypting)*:

- **Export:**
	Exports the current configuration to a user-chosen location, encrypting the file where applicable.
- **Import:**
	Imports the current configuration from a user-chosen location, decrypting the file where applicable.
- **Encryption key:**
	The encryption key that should be used to encrypt/decrypt any configuration files that are interacted with. If left empty; no encryption will occur.
- **Change-logging:**
	Whenever a change is detected, the changed version of the website will be saved with a filename consisting of the file's SHA1 and the time/date at which it was detected.

*If used, SiteMon encrypts configuration files with the .NET ``Aes`` [class](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0) with an initialization vector generated using the .NET [CSPRNG class](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rngcryptoserviceprovider?view=net-6.0) - meaning that if there is an issue/vulnerability with either of those classes, the security/integrity of this application will be impacted greatly (so keep an eye on [MSRC](https://msrc.microsoft.com/update-guide/vulnerability).)*

### Networking

*This section is focused on the networking-side of SiteMon (primarily, not spamming servers with weird logs):*

- **User-agent:**
	The value of the header ``User-Agent`` that all requests are accompanied by. If left to '[AUTO]' then a user-agent that conforms to the [RFC1945-10.15](https://www.rfc-editor.org/rfc/rfc1945#section-10.15) is specification and used (this provides servers with the version number of SiteMon.)
- **Delay (ms):**
	The time that each monitoring-thread sleeps for between site-checks, the minimum value for this is 1,500 (1.5s) to avoid causing accidental DoS or annoying server administrators with weird logs.

### Whitelist

The whitelist section is a [DataGridView](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/datagridview-control-windows-forms?view=netframeworkdesktop-4.8) with one column; 'Regex' - the input for those columns should be Regex samples, the regular expressions listed in this area are 'whitelisted' in that notifications are not created/shown for pages that (after removing Regex-applicable lines) have no changes.

## How it works:
SiteMon launches one thread for each monitoring target so that, even if something goes wrong on thread A, thread B can (in theory) continue monitoring its host, thus reducing the amount of impact an exception can have on an application.

Each of these threads enters a loop where it requests a page, removes REGEX-matching lines from it, compares the page to its previous capture, and then depending on the outcome of the aforementioned comparison, either alerts the user (depending on their configuration) or does nothing - SiteMon then sleeps for a specified delay and repeats the above steps.

## Compiling:
Compiling SiteMon can be done via [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [CSC](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/) (I believe Visual Studio uses CSC anyway) but I'd advise that you use Visual Studio as it provides more verbose error information and suggests patches with intellisense.

Simply open the ``SiteMon.sln`` file, ensure that the dropdown at the top of the window says 'Release' and not 'Debug' and press <kbd>CTRL</kbd> + <kbd>B</kbd> to start compiling/building the project. After that, an executable version of SiteMon (and some metadata files) should be in ``/bin/Release/``.
