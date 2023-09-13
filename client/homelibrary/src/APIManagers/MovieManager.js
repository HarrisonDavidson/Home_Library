import React from "react";

const baseUrl = '/api/movies';

export const getAllMovies = () => {
  return fetch(baseUrl) 
    .then((res) => res.json())
};

export const addMovie = (singleMovie) => { 
  return fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(singleMovie),
  });
};