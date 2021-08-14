# SiteMon

SiteMon is a tool that allows users to monitor specific webpages for minor/major changes based on a set of rules.

## Usage:
<center>
<img style="height: 250px;border:dotted #cccccc 2px;" src="https://i.ibb.co/fG9XvXC/SITEMON-CONFIGURATION.png"/>
</center>
The above screenshot is pretty self-explanatory of how most of the SiteMon UI is laid out and operates, here's a breakdown of its options:


| UI Name       | Description |
| ------------- | ----------- |
| 'Notification->Popup window' | Shows a popup window when a change is detected. |
| 'Notification->Open URL' | Opens the URL to a given website when a change is detected on it. |
| 'Notification->Alert sound' | Plays a sound when a change is detected. |
| 'Notification->Message-box' | Shows a messagebox/prompt when a change is detected. |
| 'IO->Export' | Export the current UI/configuration values to an external location. |
| 'IO->Import' | Imports an exported (see above) configuration/array of UI values from an external location. |
| 'IO->Change-logging' | When a change is detected, a copy of the unchanged page and changed page are written to a given location (with whitelisted lines removed). |
| 'Internet-Courtesy->User-agent:' | Changes the user-agent header value sent with all requests, if this is set to an empty string or ``[AUTO]`` SiteMon automatically generates a dynamic one that lets web-servers know the version of sitemon running, its delay period, and provides a link to the project in-case they have (and therefore would like to open) an issue. |
| 'Internet-Courtesy->Delay' | Changes the delay between requests for a given page, this is limited in the WinForms setting to 1500ms (1.5s) to avoid spamming a server with an obnoxious amount of requests, this ensures that your IP is less likely to be blocked by an automated DDoS prevention service. (Also, less resources are used within a given timescale as threads sleep for longer between requests.) I'd advise that users set this to a figure anywhere between 30s (30,000ms) to 30m (1,800,000ms). |
| 'Whitelist->[TABLE]' | A list of REGEXes that each line of a HTTP(s) response should be checked for, if the line does contain a regex on this list, it is ignored and will not be included when the current and previous pages are checked for differences. |

## How it works:
SiteMon launches one thread for each monitoring target so that, even if something goes wrong on thread A, thread B can (in theory) continue monitoring its host, thus reducing the amount of impact an exception can have on an application.
Each of these threads enters a loop where it requests a page, removes REGEX-matching lines from it, compares the page to its previous capture, and then depending on the outcome of the aforementioned comparison, either alerts the user (depending on their configuration) or does nothing - SiteMon then sleeps for a specified delay and repeats the above steps.

## Compiling:
Compiling SiteMon can be done via [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [CSC](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/) (I believe Visual Studio uses CSC anyway) but I'd advise that you use Visual Studio as it provides more verbose error information and suggests patches with intellisense.

Simply open the ``SiteMon.sln`` file, ensure that the dropdown at the top of the window says 'Release' and not 'Debug' and press <kbd>CTRL</kbd> + <kbd>B</kbd> to start compiling/building the project. After that, an executable version of SiteMon (and some metadata files) should be in ``/bin/Releases/``.