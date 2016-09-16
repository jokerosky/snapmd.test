/// <binding BeforeBuild='shell.tsc' />
/// <binding BeforeBuild='sass' />

/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var sass = require('gulp-sass');
var concatCss = require('gulp-concat-css');
var typescript = require('gulp-tsc');
var shell = require('gulp-shell');


gulp.task('default', function () {
    // place code for your default task here
});


// make it in console to avoid errors
gulp.task('shell.tsc',
    shell.task([
        'tsc'
    ]));    

// it does not work
//gulp.task('tsc', function () {
//    return gulp.src(['./wwwroot/app/**/*.ts'])
//        .pipe(typescript({
//            tscSearch:["shell"]
//        }));
//});

gulp.task('tsc:watch', function () {
    gulp.watch('./wwwroot/app/**/*.ts', ['shell.tsc']);
});

gulp.task('sass', function () {
    return gulp.src([   
                        './Assets/**/*.scss'
    ])
      .pipe(sass().on('error', sass.logError))
      .pipe(concatCss("site.css"))
      .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('sass:watch', function () {
    gulp.watch('./Assets/**/*.scss', ['sass']);
});
