VAR wantTeleport = false

ME: Seems like Alyssa's last known location has been programmed in.
ME: Am I ready to go?
    *[Yes] ME: No time to waste..
    ~wantTeleport = true
    ->END
    
    *[No] ME: Not yet.
    ->END