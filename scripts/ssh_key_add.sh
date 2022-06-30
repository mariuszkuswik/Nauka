#!/bin/bash


# Jezeli klucz ssh o podanej nazwie nie istnieje to tworzy go
if [ ! -f /home/vagrant/.ssh/id_ansible ]
then 
    ssh-keygen -t rsa -N '' -f /home/vagrant/.ssh/id_ansible
fi


# Wylistowanie hostow z pliku ini
# sed1d usuwa pierwsza linie
ansible all --list-hosts | sed 1d | while read single_host
do
    ssh-keyscan "$single_host" >> /home/vagrant/.ssh/known_hosts

    # Kopia hasla do webservera 
    sshpass -p 'vagrant' ssh-copy-id -i /home/vagrant/.ssh/id_ansible.pub vagrant@"$single_host" 
done



