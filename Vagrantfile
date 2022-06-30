# -*- mode: ruby -*-
# vi: set ft=ruby :

# Every Vagrant development environment requires a box. You can search for
# boxes at https://vagrantcloud.com/search.
  
# The most common configuration options are documented and commented below.
# For a complete reference, please see the online documentation at
# https://docs.vagrantup.com.
WEB_HOST_PORT = 80

SCRIPTS_DIR = "./scripts"

SSH_HOST_DIR = "./ssh_host"
ANS_HOST_DIR = "./ansible_host"
WEB_HOST_DIR = "./web_data_host"



Vagrant.configure("2") do |config|

  #### ANSIBLEMACHINE ####
  config.vm.define "ansiblemachine" do |ansiblemachine|
    
    ansiblemachine.vm.box = "generic/rocky8"
    ansiblemachine.vm.hostname = "ansiblemachine"

    # ansiblemachine.ssh.username = 'vagrant'
    # ansiblemachine.ssh.password = 'vagrant'
    
    ### SIEC ###
    # Siec zewnetzna potrzebna dla instalacji ansible
    ansiblemachine.vm.network "public_network", bridge: "Realtek PCIe GBE Family Controller", ip: "192.168.0.50"
    ansiblemachine.vm.network "private_network", ip: "192.168.1.50"
    
    ### DIR SYNC ###
    ansiblemachine.vm.synced_folder ANS_HOST_DIR, "/ansible_host"
    ansiblemachine.vm.synced_folder SCRIPTS_DIR, "/scripts"
    
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
    ## Update
    ansiblemachine.vm.provision "shell", inline: <<-SHELL
      echo "Update"  
      dnf update -y
      dnf install ansible sshpass -y
    SHELL

    ## SSH 
    ansiblemachine.vm.provision "shell", inline: <<-SHELL
      sed -i "s/PasswordAuthentication no/PasswordAuthentication yes/g" /etc/ssh/sshd_config
      systemctl restart sshd
    SHELL

    ## Ansible
    # Zmiana configu dla ansible, config przypisuje plik hosts
    ansiblemachine.vm.provision "shell", inline: "export ANSIBLE_CONFIG=/ansible_host/ansible.cfg"
    
  end

  #### WEBSERVER #### 
  config.vm.define "webserver" do |webserver|
    webserver.vm.box = "generic/rocky8"
    webserver.vm.hostname = "webserver"
  
    ### SIEC ###
    webserver.vm.network "public_network", bridge: "Realtek PCIe GBE Family Controller", ip: "192.168.0.51"
    webserver.vm.network "private_network", ip: "192.168.1.51"

    ### DIR SYNC ###
    webserver.vm.synced_folder WEB_HOST_DIR, "/etc/www/html"
  
    ### VIRTUALBOX WEBSERVER ###
    webserver.vm.provider "virtualbox" do |webserver|
      # GUI virtualboxa nie bedzie sie pojawiac?
      webserver.gui = false
      # Nazwa w virtualbox
      webserver.name = "webserver"
        
      webserver.memory = "1548"
      webserver.cpus = 1     
    end

    ### SHELL ###  
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

    # Wygenerowanie skryptu który tworzy klucze
    # Wykonanie skryptu przez ssh 
    webserver.vm.provision "shell", inline: <<-SHELL
        cat <<- EOF > /root/script.sh ; 
        mkdir /vagrant/.ssh ; 
        ssh-keyscan 192.168.1.51 >> /home/vagrant/.ssh/known_hosts ; 
        ssh-keygen -t rsa -N '' -f /home/vagrant/.ssh/id_ansible ; 
        # Kopia hasla do webservera ; 
        sshpass -p 'vagrant' ssh-copy-id -i /home/vagrant/.ssh/id_ansible.pub vagrant@192.168.1.51 ; 
        EOF
      SHELL
     
    webserver.vm.provision "shell", inline: "chmod 500 /root/script.sh && mkdir /root/.ssh"
    # Dodanie ansblemachine do known_hosts
    webserver.vm.provision "shell", inline: "ssh-keyscan 192.168.1.50 >> /root/.ssh/known_hosts"
    # Wykonanie skryptu na ansiblemachine
    webserver.vm.provision "shell", inline: "sshpass -p 'vagrant' ssh vagrant@192.168.1.50 'bash -s' < /root/script.sh"
    
    

  end
  
end

