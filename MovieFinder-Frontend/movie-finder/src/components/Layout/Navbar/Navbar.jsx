import "./Navbar.css";
import React from "react";
import { Link, useNavigate } from "react-router-dom";
import SearchField from "../../forms/navbar/SearchField/SearchField";

const Header = () => {
  const navigate = useNavigate();

  const setTextField = () => {
    let inputField = document.getElementById("movie-input").value;
    navigate(`/search/${inputField}`);
  };
  return (
    <div>
      <nav className="app__navbar">
        <Link to="/" className="app__header">
          MovieFinder
        </Link>

        <SearchField onClick={setTextField} placeholder="Search movie..." />

        <ul className="nav__list">
          <li className="item">
            <Link to="/random-movie-pick">Movie Picker</Link>
          </li>
          <li className="item">
            <Link to="#">Genres</Link>
          </li>
        </ul>
      </nav>
    </div>
  );
};
export default Header;
