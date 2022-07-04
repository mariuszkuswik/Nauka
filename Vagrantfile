# -*- mode: ruby -*-
# vi: set ft=ruby :

# Every Vagrant development environment requires a box. You can search for
# boxes at https://vagrantcloud.com/search.
  
# The most common configuration options are documented and commented below.
# For a complete reference, please see the online documentation at
# https://docs.vagrantup.com.
WEB_HOST_PORT = 80

SCRIPTS_DIR = "./scripts"

REP_BASEOS_DIR = "./repos/BaseOS"
REP_APPSTREAM_DIR = "./repos/AppStream"

SSH_HOST_DIR = "./ssh_host"
ANS_HOST_DIR = "./ansible_host"
WEB_HOST_DIR = "./web_data_host"

ANS_CONF = "./ansible_host/ansible.cfg"


Vagrant.configure("2") do |config|

  #### WEBSERVER #### 
  config.vm.define "webserver" do |webserver|
    webserver.vm.box = "generic/rocky8"
    webserver.vm.hostname = "webserver"
  
    ### SIEC ###
    webserver.vm.network "public_network", bridge: "Realtek PCIe GBE Family Controller", ip: "192.168.0.51"
    webserver.vm.network "private_network", ip: "192.168.1.51"

    ### DIR SYNC ###
    webserver.vm.synced_folder WEB_HOST_DIR, "/etc/www/html"
    webserver.vm.synced_folder SCRIPTS_DIR, "/scripts"

    ### VIRTUALBOX WEBSERVER ###
    webserver.vm.provider "virtualbox" do |webserver|
      # GUI virtualboxa nie bedzie sie pojawiac?
      webserver.gui = false
      # Nazwa w virtualbox
      webserver.name = "webserver"
        
      webserver.memory = "1024"
      webserver.cpus = 1     
    end

    ### SHELL ###  
    # DNS
    webserver.vm.provision "shell", inline: "nmcli con mod 'System eth2' ipv4.dns 8.8.8.8"
    
    webserver.vm.provision "shell", inline: <<-SHELL
      echo " "
      dnf install sshpass -y
      # dnf update -y
      # dnf install httpd -y
    SHELL

    ## SSH ## 
    # SSH logowanie hasłem w configu
    webserver.vm.provision "shell", inline: <<-SHELL
      sed -i "s/PasswordAuthentication no/PasswordAuthentication yes/g" /etc/ssh/sshd_config
      systemctl restart sshd
    SHELL

    # Wykonanie skryptu przez ssh  
    # webserver.vm.provision "shell", inline: "chmod 500 /scripts/ssh_key_add.sh && mkdir /root/.ssh"
    # Dodanie ansiblemachine do known_hosts
    # webserver.vm.provision "shell", inline: "ssh-keyscan 192.168.0.50 >> /root/.ssh/known_hosts"
    # Wykonanie skryptu na ansiblemachine
    # webserver.vm.provision "shell", inline: "sshpass -p 'vagrant' ssh vagrant@192.168.0.50 'bash -s' < /scripts/ssh_key_add.sh"
    

  end

  # Maszyna ma dzialac z usluga docker i na niej cos hostowac
  #### DOCKERSERVER ####
  config.vm.define "dockerserver" do |dockerserver|
    dockerserver.vm.box = "generic/rocky8"
    dockerserver.vm.hostname = "dockerserver"

    ### SIEC ###
    dockerserver.vm.network "public_network", bridge: "Realtek PCIe GBE Family Controller", ip: "192.168.0.52"
    dockerserver.vm.network "private_network", ip: "192.168.1.52"
    
    ### DIR SYNC ###
    dockerserver.vm.synced_folder SCRIPTS_DIR, "/scripts"
    dockerserver.vm.synced_folder REP_BASEOS_DIR, "/repos/BaseOS"
    

    ### VIRTUALBOX dockerserver ###
    dockerserver.vm.provider "virtualbox" do |dockerserver|
      # GUI virtualboxa nie bedzie sie pojawiac?
      dockerserver.gui = false
      # Nazwa w virtualbox
      dockerserver.name = "dockerserver"
            
      dockerserver.memory = "1024"
      dockerserver.cpus = 1     
    end

    ### SHELL ###
    # DNS
    dockerserver.vm.provision "shell", inline: "nmcli con mod 'System eth2' ipv4.dns 8.8.8.8"

  # Koniec DOCKERSERVER
  end

#### ANSIBLEMACHINE ####
config.vm.define "ansiblemachine" do |ansiblemachine|
    
  ansiblemachine.vm.box = "generic/rocky8"
  ansiblemachine.vm.hostname = "ansiblemachine"

  ### SIEC ###
  # Siec zewnetzna potrzebna dla instalacji ansible
  ansiblemachine.vm.network "public_network", bridge: "Realtek PCIe GBE Family Controller", ip: "192.168.0.50"
  ansiblemachine.vm.network "private_network", ip: "192.168.1.50"
  
  ### DIR SYNC ###
  ansiblemachine.vm.synced_folder ANS_HOST_DIR, "/ansible_host"
  ansiblemachine.vm.synced_folder SCRIPTS_DIR, "/scripts"
  # REPOS
  ansiblemachine.vm.synced_folder REP_BASEOS_DIR, "./repos/BaseOS" 
  ansiblemachine.vm.synced_folder REP_APPSTREAM_DIR, "./repos/AppStream"

  ### VIRTUALBOX ANSIBLEMACHINE ###
  ansiblemachine.vm.provider "virtualbox" do |ansiblemachine|
    # DO ZROBIENIA - sprawdzic czy na pewno
    # GUI virtualboxa nie bedzie sie pojawiac?
    ansiblemachine.gui = false
    # Nazwa w virtualbox
    ansiblemachine.name = "ansiblemachine"
    ansiblemachine.memory = "2048"
    ansiblemachine.cpus = 2       
  end

  ### SHELL ### 
  ansiblemachine.vm.provision "shell", inline: "nmcli con mod 'System eth2' ipv4.dns 8.8.8.8"
  
  ## Zmienne sredowiskowe
  # Zmiana configu dla ansible, config przypisuje plik hosts
  ansiblemachine.vm.provision "shell", inline: "echo 'export ANSIBLE_CONFIG=/ansible_host/ansible.cfg' >> /etc/bashrc && source /etc/bashrc"

  ## Update
    ansiblemachine.vm.provision "shell", inline: <<-SHELL
    # dnf update -y
    dnf install ansible sshpass -y
  SHELL

  ## SSH ##
    ansiblemachine.vm.provision "shell", inline: <<-SHELL
    sed -i "s/PasswordAuthentication no/PasswordAuthentication yes/g" /etc/ssh/sshd_config
    systemctl restart sshd
  SHELL

  # Zmiana uprawnien dla skryptu z dodawaniem kluczy
  ansiblemachine.vm.provision "shell", inline: "chmod 500 /scripts/ssh_key_add.sh && mkdir /root/.ssh"
  # Wykonanie skryptu propagujacego klucze ssh
  ansiblemachine.vm.provision "shell", inline: "/scripts/ssh_key_add.sh"
  

  ## Ansible ##
  # Master
  ansiblemachine.vm.provision "shell", inline: "/usr/bin/ansible-playbook /ansible_host/master.yml"

  # Ansiblemachine END
  end

# Config END
end

