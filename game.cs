using System;
using System.Collections.Generic;

class Game{
  // public string game;
  public Dictionary<string, string> play1 = new Dictionary<string, string>();
  public Dictionary<string, string> play2 = new Dictionary<string, string>();
  int positions = 0;
  string[,] board;
  List <Dictionary<string,string>> users = new List<Dictionary<string,string>>();
    
  public Game(string p1, string p2, int size){
    this.play1.Add("name", p1);
    this.play2.Add("name", p2);
    this.play1.Add("figure", "X");
    this.play2.Add("figure", "O");
    this.board = new string[size, size];

    this.users.Add(this.play1);
    this.users.Add(this.play2);
  }

  public void createBoard(){
    for(int i = 0; i < board.GetLength(0); i++){
      for(int j = 0; j < board.GetLength(1); j++){
        positions++;
        board[i, j] = $"{positions}";
      }
    }
  }

  public void displayBoard(){
    for(int i = 0; i < board.GetLength(0); i++){
      for(int j = 0; j < board.GetLength(1); j++){
        Console.Write(board[i, j]);
        Console.Write(" | ");
      }
      Console.WriteLine();
      if(i < board.GetLength(0) - 1){
        for(int x = 0; x < board.GetLength(0); x++){
          Console.Write("--| ");
        }
      }
      Console.WriteLine();
    }
  }
  
  public void startGame(){
    CheckPosition check_p = new CheckPosition();
    Dictionary<string,string> winner = new Dictionary<string, string>();
    string pos;
    int[] idx;
    int turn = 0;

    while(true){
      Console.Write($"{this.users[turn]["name"]} enter position: ");
      pos = Console.ReadLine();
      Console.WriteLine();
      idx = check_p.findIndex(board, pos);
      if(idx[0] != -1){
        if(turn == 0){
          board[idx[0], idx[1]] = "X";
          turn = 1;
        }else{
          board[idx[0], idx[1]] = "O";
          turn = 0;
        }
      }
      else{
        Console.WriteLine("Position is no longer available ");
      }
      this.displayBoard();
      winner = check_p.findWinner(this.board, this.users);
      if(winner["type"] == "winner"){
        Console.WriteLine($"{winner["message"]} is the winner !!!");
        Console.WriteLine();
        break;
      }
      else if(winner["type"] == "no"){
        Console.WriteLine(winner["message"]);
        Console.WriteLine();
        break;
      }
    }
  }
}