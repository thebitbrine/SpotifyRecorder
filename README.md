# TheBitBrine's Spotify Recorder v0.2
### A Tiny Tool That Records Songs From Spotify In MP3 And Tags Them.


#### Video Guide:
[![TheBitBrine's Spotify Recorder Guide](https://img.youtube.com/vi/OsTOKdp4pME/maxresdefault.jpg)](https://www.youtube.com/watch?v=OsTOKdp4pME-Y "TheBitBrine's Spotify Recorder - How To Use It")


#### How does it work?
> 1. It connects to Spotify Player's local API to grab the required info for the song (title, album, artwork etc.)
>
> 2. Then it takes control of the playback and goes to the next song and then comes back to the same song that you originally wanted to record, (It does this to set the song's playback position to zero, and as the local API does not provide any proper way to do this, it's the only way to make sure that everything gets recorded)
>
> 3. Waits 5 more seconds to make sure that Spotify does not freak out by the amount of requests in a short time period (trust me, it happens)
>
> 4. Fetches the final informations about the song, shows the artwork in the program, Starts recording and then smashes the Play button.
>
> 5. Then the TrackWatchDog watches the if the Spotify's window title changed or not. If its changes it knows that song is either finished or stopped, either way it has to stop the recording. It stops the playback then the recording, tags the MP3 file based on previously fetched info.
>
> 6. Repeat (If Playlist Mode is turned on)


#### Requirements:
 * .NET Framework 4.6.1 (The only version with required GC controls)
 * Spotify For Windows
 * Spotify Ad Blocker
 * WASAPI Loopback Driver (Most of modern operating systems have it installed by default)
 * All Notification Sounds To Be Turned Off (Like Windows Sounds, Skype, Telegram etc.)
 * Patience (All because it's a new born software and might crash if not used carefully)
 
 
#### Known Issues:
 * Artwork bitmap being used somewhere else. (UI Artwork updates messes with tagging function)
 * Random crashes due to "Garbage Collection" and LAMP library low-level issues.
 * Spofity's API not respecting the API calls. (Can be solved by restarting the Spotify Client)
 * No-Brake. It just goes on and on overwriting the previously recorded files.
 
 
#### Disclaimer:
 This software is for "educational" purposes only. No responsibility is held or accepted for misuse.
 
#### Donations:
> BTC: 1DDaiFgk3ReyK8nhXREVpF42tCbjkB3nWe

> ETH: 0xd5048876067cdeec173ea6e94c482c1575babfd1

> ZEC: t1h8SaL14xtrcEJaUbyGYYcj2RnjbBnMR7s
