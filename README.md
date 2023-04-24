# ScoreBoardLib
I found an inaccuracy related to names in spec. There is Match and there are Games in ScoreBoard. I left it unchanged, but maybe it should be fixed in spec and code. 

It is likely that there will be a requirement to display completed matches. In this case, you can immediately implement marking completed matches instead of deleting them. As there was no such requirement, and there was a requirement for simplicity, I left it as it is.

The last thing that came to my mind that it could be more elastic for changing type of games repository (e.g. DB). It could be done by defining new e.g. interface related to storage and use it in Scoreboard. I decided to mention about it but not to code. 

Merged branches intentionally left.