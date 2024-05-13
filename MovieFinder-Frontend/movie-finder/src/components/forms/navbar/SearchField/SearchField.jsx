import React from "react";
import "./SearchField.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSearch } from "@fortawesome/free-solid-svg-icons";
const SearchField = ({ onClick, placeholder }) => {
  return (
    <div className="search__bar">
      <input
        type="text"
        id="movie-input"
        placeholder={placeholder}
        className="search__input"
      />
      <button
        type="button"
        onClick={onClick}
        className="search__button"
        title="Search"
      >
        <FontAwesomeIcon icon={faSearch} />
      </button>
    </div>
  );
};

export default SearchField;
