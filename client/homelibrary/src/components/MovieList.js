import React, { useState, useEffect } from "react";
import { getAllMovies } from "../APIManagers/MovieManager";

const MovieList = () => {
  const [movies, setMovies] = useState([]);

  const getMovies = () => {
    getAllMovies().then(allMovies => setMovies(allMovies)); 
  };

  useEffect(() => {
    getMovies();
  }, []); 



  return (  
    <div>
      {movies.map((movie) => (
        <div key={movie.id}>
          <img src={movie.image} alt={movie.name} />
          <p>
            <strong>{movie.name}</strong>
          </p>
          <p>{movie.notes}</p>
        </div>
      ))}
    </div>
  );
};

export default MovieList;