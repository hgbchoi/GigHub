/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass");

// other content removed
gulp.task("sass", () => {
    return gulp.src("../Content/sass/**/*.scss")
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest("../Content/"));
});

gulp.task("watch", function () {
    gulp.watch("../Content/sass/**/*.scss", ["sass"]);    
});