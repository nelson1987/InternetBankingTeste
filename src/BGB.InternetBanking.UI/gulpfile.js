var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');

var destLibPath = './wwwroot/lib/';

gulp.task('cleanAll', function () {
    return gulp.src([destLibPath, destAppPath])
        .pipe(clean());
});
gulp.task("libraries", function () {
    gulp.src([
        'core-js/client/*.js',
        'systemjs/dist/*.js',
        'reflect-metadata/*.js',
        'rxjs/**',
        'zone.js/dist/*.js',
        '@angular/**/bundles/*.js',
        "@ngrx/**/bundles/*.js",
        'bootstrap/dist/js/*.js',
        'bootstrap/dist/css/*.css',
        'bootstrap/dist/fonts/*.*'
    ], {
            cwd: "node_modules/**"
        })
        .pipe(gulp.dest(destLibPath));
});
gulp.task('default', ['cleanAll', 'libraries']);