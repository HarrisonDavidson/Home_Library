using HomeLibrary.Models;
using Microsoft.Data.SqlClient;

namespace HomeLibrary.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly string _connectionString;
        public MoviesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Movies> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, [Name], YearReleased, Image, Format, Notes FROM Movies;";
                    var reader = cmd.ExecuteReader();
                    var movies = new List<Movies>();
                    while (reader.Read())
                    {
                        var movie = new Movies()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            YearReleased = reader.GetString(reader.GetOrdinal("YearReleased")),
                            Image = reader.GetString(reader.GetOrdinal("image")),
                            Format = reader.GetString(reader.GetOrdinal("format")),
                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("Notes")))
                        {
                            movie.Notes = reader.GetString(reader.GetOrdinal("Notes"));
                        }
                        movies.Add(movie);
                    }

                    reader.Close();

                    return movies;
                }
            }
        }

        public Movies Get(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, [Name], YearReleased, Image, Format, Notes 
                          FROM Movies
                         WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    Movies movies = null;
                    if (reader.Read())
                    {
                        movies = new Movies()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            YearReleased = reader.GetString(reader.GetOrdinal("Region")),
                            Image = reader.GetString(reader.GetOrdinal("Image")),
                            Format = reader.GetString(reader.GetOrdinal("Format")),
                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("Notes")))
                        {
                            movies.Notes = reader.GetString(reader.GetOrdinal("Notes"));
                        }
                    }

                    reader.Close();

                    return movies;
                }
            }
        }

        public void Add(Movies movies)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO BeanVariety ([Name], YearReleased, Image, Format, Notes)
                        OUTPUT INSERTED.ID
                        VALUES (@name, @region, @notes)";
                    cmd.Parameters.AddWithValue("@name", movies.Name);
                    cmd.Parameters.AddWithValue("@yearreleased", movies.YearReleased);
                    cmd.Parameters.AddWithValue("@image", movies.Image);
                    cmd.Parameters.AddWithValue("@format", movies.Format);
                    if (movies.Notes == null)
                    {
                        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@notes", movies.Notes);
                    }

                    movies.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Movies movies)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Movies 
                           SET [Name] = @name, 
                               YearReleased = @yearreleased,
                               Image = @image,
                               Format = @format,
                               Notes = @notes
                         WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", movies.Id);
                    cmd.Parameters.AddWithValue("@name", movies.Name);
                    cmd.Parameters.AddWithValue("@yearreleased", movies.YearReleased);
                    cmd.Parameters.AddWithValue("@image", movies.Image);
                    cmd.Parameters.AddWithValue("@format", movies.Format);
                    if (movies.Notes == null)
                    {
                        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@notes", movies.Notes);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Movies WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}