import { Route, Routes, Navigate } from "react-router-dom";
import MovieList from "./MovieList";

const ApplicationViews = () => {
return (
    <Routes>
        
        <Route path="/" element= {<MovieList />} />

    </Routes>
)

};

export default ApplicationViews;