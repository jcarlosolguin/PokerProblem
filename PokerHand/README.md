# Poker Hand
This app implements only 4 types of winning hands: flush, three of a kind, pair and high card.

#### Input
Each odd line expects a name of a player. Each even line expects 5 card names, comma separated.

If the program recieves an empty line, it will try to resolve the winners after pressing enter.

The first part of the card name is the value of the card, from A to K. The second part is the initial letter of the suit name.

For example:

```
Joe
8S, 8D, AD, QD, JH 
Bob
AS, QS, 8S, 6S, 4S 
Sally
4S, 4H, 3H, QC, 8C
```

#### Number of Players
Minimum is 2 players, maximum is 10.

#### Winners
Thew winners are selected using the standard rules, and tie breakers. 

If more than one winner has the same high value cards, more than one winner will be printed in the order they were input.

#### Exceptions

The game is pretty unforgiven. It will halt when:

- It gets a wrong formatted card.
- Gets a repeated card. 
- Gets the wrong number of cards.
- Gets the wrong number of players.