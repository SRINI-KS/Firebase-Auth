#!/bin/bash
ROOTDIRECTORY=$(cd -P -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd -P)
cd "$ROOTDIRECTORY"/SProvider.Models
echo "The current directory is : Expecting Model folder"
pwd
echo cma2020# | sudo -s  dotnet build
cd "$ROOTDIRECTORY"/SProvider.DAL
echo "The current directory is : Expecting DAL folder"
pwd
echo cma2020# | sudo -s  dotnet build
cd "$ROOTDIRECTORY"/
echo cma2020# | sudo -s  rm -f "$ROOTDIRECTORY"/SProvider.sln
echo cma2020# | sudo -s  dotnet new sln --name SProvider
echo cma2020# | sudo -s  dotnet sln add "$ROOTDIRECTORY"/SProvider.Models/SProvider.Models.csproj
echo cma2020# | sudo -s  dotnet sln add "$ROOTDIRECTORY"/SProvider.DAL/SProvider.DAL.csproj



                    cd "$ROOTDIRECTORY"/SProviderWebApi
                    echo cma2020# | sudo -s  dotnet build
                    echo cma2020# | sudo -s  dotnet publish -o "$ROOTDIRECTORY"/Publish/WebApi
cd "$ROOTDIRECTORY"
                cd "$ROOTDIRECTORY"/Admin
                echo cma2020# | sudo -s  dotnet build
                echo cma2020# | sudo -s  dotnet publish -o "$ROOTDIRECTORY"/Publish/Admin
                echo cma2020# | sudo -s  mkdir "$ROOTDIRECTORY"/Publish/Admin/wwwroot/uploads
                echo cma2020# | sudo -s  cp /home/ubuntu/Automaton/AutomatonClient/wwwroot/BackupFiles/SProvider/AdminUploads/*.* "$ROOTDIRECTORY"/Publish/Admin/wwwroot/uploads


echo "Setting up the Publish Evnrionment"
                        cd /home/ubuntu/Automaton/AutomatonClient/wwwroot/PublishedFiles
                        echo cma2020# | sudo -s  chown -R ubuntu SProvider
                        cd "$ROOTDIRECTORY"
                        echo cma2020# | sudo -s  rm -f /etc/nginx/sites-enabled/mahatintern06
                        echo cma2020# | sudo -s  rm -f /etc/supervisor/conf.d/SProviderWebApi.conf
                        echo cma2020# | sudo -s  rm -f /etc/supervisor/conf.d/SProviderClient.conf
                        echo cma2020# | sudo -s  rm -f /etc/supervisor/conf.d/SProviderAdmin.conf
                        echo cma2020# | sudo -s  cp "$ROOTDIRECTORY"/PublishRequisites/*.conf /etc/supervisor/conf.d/
                        echo cma2020# | sudo -s  cp "$ROOTDIRECTORY"/PublishRequisites/mahatintern06 /etc/nginx/sites-enabled/
                        echo cma2020# | sudo -s  supervisorctl reread
                        echo cma2020# | sudo -s  supervisorctl update
                        echo cma2020# | sudo -s  supervisorctl restart SProviderWebApi
                        echo cma2020# | sudo -s  supervisorctl restart SProviderClient
                        echo cma2020# | sudo -s  supervisorctl restart SProviderAdmin 
                        echo cma2020# | sudo -s  service nginx reload
curl -v --header "Connection: keep-alive" "http://localhost:5011/ContactUs/sentPublishedNotification?projectid=e50bf723-31d0-456b-80dd-07745731cd9e"
sudo -s /home/ubuntu/Automaton/AutomatonClient/wwwroot/git.sh SProvider "2024-03-28 06:42" https://mahatintern06:glpat-c8UrAe2JWMtU-gkdSNVB@sandbox-git.mahat.ai/mahatintern06/SProvider mahatintern06 glpat-c8UrAe2JWMtU-gkdSNVB

