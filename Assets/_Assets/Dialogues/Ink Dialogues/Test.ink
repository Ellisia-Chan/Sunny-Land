Hello there! #speaker:NPC
I have a question for you.
What is it? #speaker:PLAYER
-> main

=== main ===
Are you Happy? #speaker:NPC
    + [Yes]
        Yes #speaker:PLAYER
        -> chosen(0)
    + [No]
        No #speaker:PLAYER
        -> chosen(1)
    + [Maybe?]
        Maybe? #speaker:PLAYER
        -> chosen(2)
     
=== chosen(answer) ===
{answer == 0:
    That's great! Keep smiling! #speaker:NPC
}
{answer == 1:
    I'm sorry to hear that. Hope things get better soon. #speaker:NPC
}
{answer == 2:
    Uncertainty is okay. Take your time to figure things out. #speaker:NPC
}

Thank you! #speaker:PLAYER
-> END