using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WorldData.Models
{
  public class CountryDB
  {
    private string _code = "";
    private string _countryName = "";
    private int _countryPop;
    public CountryDB(string code, string countryName, int countryPop)
    {
      _countryName = countryName;
      _countryPop = countryPop;
      _code = code;
    }
    public string GetCountryName()
    {
      return _countryName;
    }
    public int GetCountryPop()
    {
      return _countryPop;
    }
    public static List<CountryDB> GetAll()
    {
      List<CountryDB> allItems = new List<CountryDB> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryCode = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        int countryPop = rdr.GetInt32(6);
        CountryDB newCountryDB = new CountryDB(countryCode, countryName, countryPop);
        allItems.Add(newCountryDB);
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
