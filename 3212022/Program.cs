using _3212022.Models;
using Microsoft.Data.Sqlite;

using (var conn = new SqliteConnection(@"Data Source=C:\Users\desjardinsm\source\repos\3212022\3212022\Data\database.sqlite"))
{
    /*
    conn.Open();

    var command = conn.CreateCommand();

    command.CommandText = "select * from People";

    var reader = command.ExecuteReader();

    People data;

    //typeof(T).Name;

    var datas = new List<People>();

    while (reader.Read())
    {
        data = new People();

        //data.Id = reader.GetInt32(0);
        for (int i = 0; i < reader.FieldCount; i++)
        {
            typeof(People).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
        }
        
        //data.FirstName = reader.GetString(1);
        //data.LastName = reader.GetString(2);
        //data.Birthdate = reader.GetString(3);

        datas.Add(data);
    }

    foreach (var item in datas)
    {
        Console.WriteLine(item.Id);
        //Console.WriteLine(item.Name);
    }
    */

    var data = ReadAll<People>(conn);
}

static List<T> ReadAll<T>(SqliteConnection conn) where T : new()
{
    conn.Open();

    var command = conn.CreateCommand();

    command.CommandText = $"select * from {typeof(T).Name}";

    var reader = command.ExecuteReader();

    T data;

    var datas = new List<T>();

    while (reader.Read())
    {
        data = new T();

        //data.Id = reader.GetInt32(0);
        for (int i = 0; i < reader.FieldCount; i++)
        {
            typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
        }

        //data.FirstName = reader.GetString(1);
        //data.LastName = reader.GetString(2);
        //data.Birthdate = reader.GetString(3);

        datas.Add(data);
    }

    return datas;
}