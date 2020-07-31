using System;

class Initiate{
  
  public void intiateGame(){
    Console.WriteLine("Enter first user's name");
    string name1 = Console.ReadLine();
    Console.WriteLine("Enter Second user's name");
    string name2 = Console.ReadLine();
    Console.Write("Enter game size: ");
    string str_size = Console.ReadLine();
    int size = 3;
    try{
      size = int.Parse(str_size);
      Console.WriteLine($"Game size {size}x{size}");
      Console.WriteLine();
    }catch (Exception e){
      Console.WriteLine("Default size selected 3x3");
      Console.WriteLine();
    }
    
    Game game = new Game(name1, name2, size);

    game.createBoard();
    game.displayBoard();
    game.startGame();
  }
}