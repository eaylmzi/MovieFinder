import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import RandomMoviePicker from "./pages/RandomMoviePicker/RandomMoviePicker.jsx";
import Layout from "./components/Layout/Layout.jsx";
import Home from "./pages/Home/Home.jsx";
import Search from "./pages/Search/Search.jsx";
import Title from "./pages/Title/Title.jsx";
function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route element={<Layout />}>
            <Route path="/" element={<Home />} />
            <Route path="/random-movie-pick" element={<RandomMoviePicker />} />
            <Route path="/search/:movieName" element={<Search />} />
            <Route path="/title/:movieData" element={<Title />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
