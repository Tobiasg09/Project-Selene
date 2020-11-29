VAR wantTeleport = false

ME: Do I want a ride towards the State base entrance?
    *[Yes] ME: Let's go.
    ~wantTeleport = true
    ->END
    
    *[No] ME: Not yet.
    ->END