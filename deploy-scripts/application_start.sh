/usr/bin/chmod 777 -R /home/ubuntu/app
/usr/bin/dotnet publish /home/ubuntu/app -o /home/ubuntu/app/build
systemctl enable website.service
systemctl start website.service
