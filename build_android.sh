#!/bin/sh

# build Android library
cd StfalconImageViewer
gradle assembleRelease
cd ..

# copy libraries to the Xamarin project
cp StfalconImageViewer/imageviewer/build/outputs/aar/imageviewer-release.aar Xamarin.Bindings.StfalconImageViewer/Jars/imageviewer-release.aar

# build Xamarin Bindings
nuget restore
msbuild /t:Rebuild /p:Configuration=Release Xamarin.Bindings.StfalconImageViewer/Xamarin.Bindings.StfalconImageViewer.csproj

mkdir -p _builds/imageviewer
cp Xamarin.Bindings.StfalconImageViewer/bin/Release/ImageViewer.dll _builds/imageviewer/
mv Xamarin.Bindings.StfalconImageViewer/bin/Release/Xamarin.Bindings.StfalconImageViewer.*.nupkg Xamarin.Bindings.StfalconImageViewer/bin/Release/Xamarin.Bindings.StfalconImageViewer.nupkg
cp Xamarin.Bindings.StfalconImageViewer/bin/Release/*.nupkg _builds/nugets/
cp Xamarin.Bindings.StfalconImageViewer/bin/Release/*.nuspec _builds/nugets/