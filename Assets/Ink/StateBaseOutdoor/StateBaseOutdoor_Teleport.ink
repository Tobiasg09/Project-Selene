VAR wantTeleport = false

ME: Do I want a ride back towards our section?
    *[Yes] ME: Let's go.
    ~wantTeleport = true
    ->END
    
    *[No] ME: Another time.
    ->END