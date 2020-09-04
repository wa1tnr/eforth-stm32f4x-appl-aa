
Turnkey - when the 'newchar>' word was run, it
modified the Forth dictionary - in RAM or perhaps
in flash (not checked).

At some point a new TURNKEY was done, and that
was done only after 0 ERASE_SECTOR (and also,
1 ERASE_SECTOR).


The newer TURNKEY retained the change made only
by running the newchar> word - this means that
the newchar> word, one way or the other, modified
a previously defined word ('>CHAR')

: newchar> 2E 900 ! ; \ location 900 has the underscore for the tochar word
\ upstream used 5F not 2E there.
\ >CHAR is that word and is stored near location 900 in RAM


Bottom line: the newchar> word modified the dictionary,
using only '2E 900 !' as its actions, and a subsequent
TURNKEY captured the change, permanently.

That seems to make the case for 'modify it in RAM, and
capture it with a TURNKEY' as one route to development.

It may not be linear (poorly documented by the source
code that causes part of the change) but it is effective.

Could be important to document or to do this in a way that
the source code does capture.

Eventually, a single .fs file is to be loaded (ASCII upload)
which in turn causes a good TURNKEY from a distribution
(pristine) upstream binary image of the initial firmware.
