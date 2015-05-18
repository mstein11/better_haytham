
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>PAIRING CODE: 1234

Roomba control:

I used this program to experiment with the the Roomba open interface. It is not intended as a finished product but as an example of what can be done (and to discover where there are limitations!). Here's a summary of features and limitations:

Features:
- Sending of raw commands (binary or text)
- Basic control (fwd, back, turn, brushes, clean...)
- Polling of sensor groups
- Recording of (one set of) actions
- Graphical path tracking using angle and distance sensors

Limitations:
- It was tested with a Roomba 560 (presumably with other 500 series models too), but since the ROI has changed, it will not work with older models.
- It was tested with a firefly-based Rootooth, and may need to be adapted to work with other bluetooth interfaces (especially the initialisation sequence : $$$, U,155k,N)
- The stream interface seems to produce too much data for the bluetooth link (or my computer perhaps) so I reverted to polling values instead.
- The path tracking only works when the relevant sensors (angle and distance) are selected (e.g. group 0, 2, 6 or 100)
- The accuracy of the path tracking is very poor (I assume because the angles reported are too small, especially when the polling rate is high). Perhaps a better result can be achieved using other sensors...
- Oh, and it writes 'Rob' on the Roomba, so if yours isn't called Rob, you'll have to change that ;-)

Have fun and share any improvements...