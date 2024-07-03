# Manticore Defense Game

This program is a two-player game where one player, the pilot of the Manticore, sets the distance of the Manticore from the city of Consolas. The second player, controlling the city’s defenses, attempts to guess this distance to destroy the Manticore before it can destroy the city.

## Objectives

The game starts with the Manticore having 10 health points and the city having 15 health points. The first player, the pilot of the Manticore, chooses the distance of the Manticore from the city within the range of 0 to 100. Once the distance is set, the screen is cleared.

The game runs in a loop until either the Manticore’s or the city’s health reaches 0. Before each turn of the second player, who controls the city’s defenses, the game displays the current round number, the city’s health, and the Manticore’s health. The damage dealt by the city’s cannon in each round depends on the round number: 10 points if the round number is a multiple of both 3 and 5, 3 points if it is a multiple of 3 or 5 (but not both), and 1 point otherwise. This damage is displayed to the player.

The second player guesses the target range and is informed whether they overshot (too far), fell short (not far enough), or hit the Manticore. If the guess is correct, the Manticore’s health is reduced by the calculated damage amount. If the Manticore survives the round, the city’s health is reduced by 1. The game advances to the next round.

The game ends when either the Manticore’s or the city’s health reaches 0, at which point the outcome is displayed. 
