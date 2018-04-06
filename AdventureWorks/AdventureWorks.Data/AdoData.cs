using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using lib = AdventureWorks.Library.Models;

namespace AdventureWorks.Data
{
  public class AdoData
  {
    private string dbconnect = "data source=adventureworks.cvoui7q38caj.us-east-2.rds.amazonaws.com;initial catalog=AdventureWorks;user id=sqladmin;password=password12345;";

    public string ReadConnected()
    {
      SqlDataReader dr;
      string q = "select firstname, lastname from person.person;";
      SqlCommand sc = new SqlCommand(q);
      var count = 0;
      var sb = new StringBuilder();

      using (SqlConnection c = new SqlConnection(dbconnect))
      {
        c.Open();
        sc.Connection = c;

        dr = sc.ExecuteReader();

        while (dr.Read() && count < 10)
        {
          sb.AppendLine(string.Format("{0} {1}", dr["firstname"], dr[1]));
          count += 1;
        }
      }

      return sb.ToString();
    }

    public string ReadConnected(string query)
    {
      SqlDataReader dr;
      var sp = new SqlParameter("id", query);
      string q = "select firstname, lastname from person.person where businessentityid = @id;";
      SqlCommand sc = new SqlCommand(q);
      var count = 0;
      var sb = new StringBuilder();

      using (SqlConnection c = new SqlConnection(dbconnect))
      {
        c.Open();
        sc.Parameters.Add(sp);
        sc.Connection = c;

        dr = sc.ExecuteReader();

        while (dr.Read() && count < 10)
        {
          sb.AppendLine(string.Format("{0} {1}", dr["firstname"], dr[1]));
          count += 1;
        }
      }

      return sb.ToString();
    }

    public string ReadDisconnected()
    {
      SqlDataAdapter da = new SqlDataAdapter();
      DataSet ds = new DataSet();
      string q = "select firstname, lastname from person.person;";
      var sb = new StringBuilder();
      var count = 0;
      
      using (var c = new SqlConnection(dbconnect))
      {
        var sc = new SqlCommand(q);
        sc.Connection = c;
        da.SelectCommand = sc;
        da.Fill(ds);
      }

      foreach (DataRow item in ds.Tables[0].Rows)
      {
        if (count > 9)
        {
          break;
        }

        sb.AppendLine(string.Format("{0} {1}", item[0], item["lastname"]));
        count += 1;
      }

      return sb.ToString();
    }

    public List<lib.Person> ReadConnected2()
    {
      SqlDataReader dr;
      string q = "select firstname, lastname from person.person;";
      SqlCommand sc = new SqlCommand(q);
      var count = 0;
      var lp = new List<lib.Person>();

      using (SqlConnection c = new SqlConnection(dbconnect))
      {
        c.Open();
        sc.Connection = c;

        dr = sc.ExecuteReader();

        while (dr.Read() && count < 10)
        {
          lp.Add(new lib.Person() { Name = new lib.Name() {First = dr["firstname"].ToString(), Last = dr["lastname"].ToString()} });
          count += 1;
        }
      }

      return lp;
    }

    public bool Insert()
    {
      int result;
      using (var c = new SqlConnection(dbconnect))
      {
        //var da = new SqlDataAdapter();
        var sc = new SqlCommand("insert into Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, rowguid, SpatialLocation)values ('tampa', null, 'fowler ave', 15, 33602, '2018-03-20', '4d1b4626-e935-49dd-8a9c-a73a8d06101c', 0xE6100000010C2E5A039B50B84740F73F30C840805EC0);");
        sc.Connection = c;
        result = sc.ExecuteNonQuery();
        //da.InsertCommand = sc;
        //da.Fill();

        sc.CommandText = "insert into Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, rowguid, SpatialLocation)values ('tampa', null, 'fowler ave', 15, 33602, '2018-03-20', '4d1b4626-e935-49dd-8a9c-a73a8d06101c', 0xE6100000010C2E5A039B50B84740F73F30C840805EC0)";
        sc.CommandType = CommandType.StoredProcedure;
        result = sc.ExecuteNonQuery();
      }

      return result == 1;
    }
  }
}
