using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class City
  {
    private int _id;
    private string _name;
    private string _district;
    private int _population;

    public City(string Name, string District, int Population, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _district = District;
      _population = Population;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetDistrict()
    {
      return _district;
    }

    public void SetDistrict(string newDistrict)
    {
      _district = newDistrict;
    }
    public int GetPopulation()
    {
      return _population;
    }

    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;

    }
    public static List<City> GetAll()
    {
      List<City> allCitys = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityDistrict, cityPopulation, cityId);
        allCitys.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCitys;
    }
    public static List<City> GetMostPopulous(int inputPopulation)
    {
      List<City> allCitys = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city WHERE population > '" + inputPopulation + "' ORDER BY population DESC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityDistrict, cityPopulation, cityId);
        allCitys.Add(newCity);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allCitys;
    }
    public static List<City> GetAlphabetically(string inputName)
    {
      List<City> allCitys = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city WHERE district > '" + inputName + "' ORDER BY name ASC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityDistrict, cityPopulation, cityId);
        allCitys.Add(newCity);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allCitys;
    }
  }
}
