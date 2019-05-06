using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class CityDB
  {
    private int _id;
    private string _cityName = "";
    private int _cityPop;
    public CityDB(int id, string cityName, int cityPop)
    {
      _cityName = cityName;
      _cityPop = cityPop;
      _id = id;
    }
    public string GetCityName()
    {
      return _cityName;
    }
    public int GetCityPop()
    {
      return _cityPop;
    }
    public static List<CityDB> GetAll()
    {
      List<CityDB> allItems = new List<CityDB> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int CityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        int cityPop = rdr.GetInt32(4);
        CityDB newCityDB = new CityDB(CityId, cityName, cityPop);
        allItems.Add(newCityDB);
      }
      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }
  }
}
