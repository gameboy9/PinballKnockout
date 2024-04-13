# PinballKnockout
This is a simulation of pinball knockout tournaments, where it will estimate the number of rounds a tournament will take.

This is similar to the TGP Calculator used here:  https://strikestgp.slapsave.com/
In turn, that calculator used Keith P. Johnson's strikes simulator, the code of which is found here:  http://tiltforums.com/t/thoughts-on-group-knockout-strikes-format-w-3-strikes-per-group/2166/119

There are some differences between that and this, though:
- I have discovered that the TGP calculator used by the IFPA assumes that all players are of the exact same ability.  This virtually never happens, even at the top levels of play.
  - Therefore, I added a "best player score" and a "worst player score".  The defaults are 40,000 and 10,000, resulting in a "best player winning percentage" of about 87%.
  - The result of this is that estimations of tournaments, using default settings of this program, approximately 8-14% longer, depending on the length of the tournament!
- This calculator had the average rounds and meaningful games like the TGP calculator, but there are a few more things I added:
  - I added the approximate TGP%.  It's simply meaningful games times 4.
  - I added the least rounds and most rounds of the 10,000 simulations the program runs.
  - I also added a 2 standard deviation range, and a "5th percentile" and "95th percentile" range.
    - This can be helpful for tournament directors in the planning of their tournaments.
   
Please write up an issue if you find a bug.  Thank you very much!
