class MovieViewModel {
  constructor(data) {
    this.name = data.name || "";
    this.poster = data.poster || "";
    this.point = data.point || 0.0;
    this.duration = data.duration || 0;
    this.year = data.year || 0;
    this.description = data.description || "";
    this.director_name = data.directorName || "";
    this.stars_name = data.starsName || [];
    this.writers_name = data.writersName || [];
    this.movie_types_name = data.movieTypesName || [];
  }
}
export default MovieViewModel;
// DB DEKİ THE GODFATHERİ the godfatherre dönüştür lower case
