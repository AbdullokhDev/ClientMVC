chmod 777 -R ../
dotnet publish ../ -o ../build
systemctl enable website.service
systemctl start website.service
