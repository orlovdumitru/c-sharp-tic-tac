using System;
using System.Collections.Generic;

class CheckPosition{

  public bool check(string[,] arr, int x, int y){
    if(arr[x,y] == "O" || arr[x,y] == "X"){
      return false;
    }
    return true;
  }

  public int[] findIndex(string[,] arr, string spot){
    int[] ar = new int[2];
     for(int i = 0; i < arr.GetLength(0); i++){
      for(int j = 0; j < arr.GetLength(1); j++){
        if(arr[i,j] == spot){
          ar[0] = i;
          ar[1] = j; 
          return ar;
        }
      }
    }
    ar[0] = -1;
    return ar;
  }

  public Dictionary<string, string> findWinner(string[,] arr, List<Dictionary<string, string>> users){

    string x_winner = "";
    string o_winner = "";
    foreach(var element in users){
      if(element["figure"] == "X"){
        x_winner = element["name"];
      }
      if(element["figure"] == "O"){
        o_winner = element["name"];
      }
    }

    Dictionary<string, string> winn = new Dictionary<string, string>(); 
    int filled_spots = 0;
    int x_points = 0;
    int o_points = 0;
    int x_v_points = 0;
    int o_v_points = 0;
    int x_z_points = 0;
    int o_z_points = 0;
    int x_z1_points = 0;
    int o_z1_points = 0;
    int arr_size = arr.GetLength(0);

    for(int i = 0; i < arr.GetLength(0); i++){
      for(int j = 0; j < arr.GetLength(1); j++){

        if(arr[i,j] == users[0]["figure"] || arr[i,j] == users[1]["figure"]){
          filled_spots++;
          if(filled_spots == (arr.GetLength(0) * arr.GetLength(0)) ){
             winn.Add("type", "no");
             winn.Add("message", "No winner and no more available spots");
            return winn;
          }
        }
        // horizontal
        if(arr[i,j] == "O"){
          o_points++;
        }
        if(arr[i,j] == "X"){
          x_points++;
        }
        
        // vertical
        if(arr[j,i] == "O"){
          o_v_points++;
        }
        if(arr[j,i] == "X"){
          x_v_points++;
        }

        // diagonal top-left -> bottom-right
        if((arr[i,j] == "O") && (i == j)){
          o_z_points++;
        }
        if((arr[i,j] == "X") && (i == j)){
          x_z_points++;
        }
        // diagonal bottom-left -> top-right
        if((arr[i,j] == "O") && (i + j == arr_size-1)){
          o_z1_points++;
        }
        if((arr[i,j] == "X") && (i + j == arr_size-1)){
          x_z1_points++;
        }

        if(o_points == arr_size || o_v_points == arr_size || o_z_points == arr_size || o_z1_points == arr_size){
          winn.Add("type", "winner");
          winn.Add("message", o_winner);
          return winn;
        }
        else if(x_points == arr_size || x_v_points == arr_size || x_z_points == arr_size || x_z1_points == arr_size){
          winn.Add("type", "winner");
          winn.Add("message", x_winner);
          return winn;
        }
      }
      x_points = 0;
      o_points = 0;
      x_v_points = 0;
      o_v_points = 0;
    }
    winn.Add("type", "pass");
    winn.Add("message", "No winner");
    return winn;
  }

}