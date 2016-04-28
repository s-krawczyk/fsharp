module Monopoly.Data

let Board =
    [ Go;
      Property "Old Kent Road"; CommunityChest 1; Property "Whitechapel Road";
      Tax "Income Tax"; Station "Kings Cross";
      Property "Angel Islington"; Chance 1; Property "Euston Road"; Property "Pentonville Road";
      Jail;
       
      Property "Pall Mall"; Utility "Electric Company"; Property "Whitehall"; Property "Northumberland Avenue";
      Station "Marylebone Road";
      Property "Bow Street"; CommunityChest 2; Property "Marlborough Street"; Property "Vine Street";
      FreeParking;
       
      Property "Strand"; Chance 2; Property "Fleet Street"; Property "Trafalgar Square";
      Station "Fenchurch Street";
      Property "Leicester Square"; Property "Coventry Street"; Utility "Water Works"; Property "Piccadilly";
      GoToJail;
       
      Property "Regent Street"; Property "Oxford Street"; CommunityChest 3; Property "Bond Street";
      Station "Liverpool Street"; Chance 3;
      Property "Park Lane"; Tax "Super Tax"; Property "Mayfair"; ]
