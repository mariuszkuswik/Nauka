Red Hat Certified System Administrator (EX200) - v8 Exam Challenge Lab
Introduction
In this hands-on lab, we will prepare for the Red Hat EX200 v8 exam. We will encounter a number of exercises that cover all the sections of the course. Upon successful mastery of this lab, students will be ready to take the RHCSA v8 exam.

You have been provided with two RHEL 8 servers, server1 and server2. You will be presented with a number of objectives, each with one or more tasks to complete. Some of the tasks will be performed on one server only, some on both. Most tasks will be performed as the root user, but not all. Pay close attention to what needs to be done, where, and as which user!

Solution
Log in to the lab server using the credentials provided:

ssh cloud_user@<PUBLIC_IP_ADDRESS>
Note: When copying and pasting code into Vim from the lab guide, first enter :set paste (and then i to enter insert mode) to avoid adding unnecessary spaces and hashes. To save and quit the file, press Escape followed by :wq. To exit the file without saving, press Escape followed by :q!.

Managing RHEL 8 Servers
Create Users/Groups and Configure Superuser Access on server1 and server2
Use a for loop to create the groups:
for group in dba_admin dba_intern dba_staff dba_managers it_staff it_managers; do echo  "Creating the "$group" group." ; groupadd $group ; done
Use a for loop to create the new users:
for user in manny moe jack marcia jan cindy ; do echo "Creating the "$user" user." ; useradd -m $user ; done
Modify the users' group ID and user ID:
usermod -u 1010 -G dba_admin,dba_managers,dba_staff manny
usermod -u 1011 -G dba_admin,dba_staff moe
usermod -u 1012 -G dba_intern,dba_staff jack
usermod -u 1013 -G it_staff,it_managers marcia
usermod -u 1014 -G dba_admin,dba_staff jan
usermod -u 1015 -G dba_intern,dba_staff cindy
Modify the users' group ID and UID:
groupmod -g 1010 manny
groupmod -g 1011 moe
groupmod -g 1012 jack
groupmod -g 1013 marcia
groupmod -g 1014 jan
groupmod -g 1015 cindy
Fix the group ownership for the home directory:
for user in manny moe jack marcia jan cindy ; do echo "Fixing home directory group ownership for "$user"..." ; chgrp -R $user /home/$user ; done
Set user passwords:
for user in manny moe jack marcia jan cindy ; do echo "Setting password for "$user"..." ; usermod -p $(openssl passwd -1 dbapass) $user ; done
Edit /etc/sudoers file:
visudo
Uncomment SOFTWARE, SERVICES, and PROCESSES command aliases.
Add a new command alias for messages logs under ## Drivers:
## Message Log
Cmnd_Alias MESSAGES = /bin/tail -f /var/log/messages
Add permissions for our groups under %wheel ALL=(ALL) ALL:
%dba_managers    ALL=(ALL)    ALL
%dba_admin       ALL=SOFTWARE, SERVICES, PROCESSES
%dba_intern      ALL=MESSAGES
Save and quit /etc/sudoers file:
:wq
Configure yum Repositories on Both Servers and Install Packages/Modules on server1 and server2
Check for configured repositories:
ls -al /etc/yum.repos.d/
Check for existing repositories:
yum repolist --all
Open a new configuration file for editing:
vi /etc/yum.repos.d/epel.repo
Add the following information:
[epel]
name=Extra Packages for Enterprise Linux
baseurl=https://download.fedoraproject.org/pub/epel/$releasever/Everything/$basearch
enabled=1
gpgcheck=0
Save and quit /etc/yum.repos.d/epel.repo file:
:wq
Open a new configuration file for editing:
vi /etc/yum.repos.d/rhel-8-appstream.repo
Add the following information:
[rhel-8-appstream-rhui-rpms]
name=Red Hat Enterprise Linux 8 for $basearch - AppStream from RHUI (RPMs)
mirrorlist=https://rhui3.REGION.aws.ce.redhat.com/pulp/mirror/content/dist/rhel8/rhui/$releasever/$basearch/appstream/os
enabled=1
gpgcheck=1
gpgkey=file:///etc/pki/rpm-gpg/RPM-GPG-KEY-redhat-release
sslverify=1
sslclientkey=/etc/pki/rhui/content-rhel8.key
sslclientcert=/etc/pki/rhui/product/content-rhel8.crt
sslcacert=/etc/pki/rhui/cdn.redhat.com-chain.crt
Save and quit /etc/yum.repos.d/rhel-8-appstream.repo file:
:wq
Open a new configuration file for editing:
vi /etc/yum.repos.d/rhel-8-baseos.repo
Add the following information:
[rhel-8-baseos-rhui-rpms]
name=Red Hat Enterprise Linux 8 for $basearch - BaseOS from RHUI (RPMs)
mirrorlist=https://rhui3.REGION.aws.ce.redhat.com/pulp/mirror/content/dist/rhel8/rhui/$releasever/$basearch/baseos/os
enabled=1
gpgcheck=1
gpgkey=file:///etc/pki/rpm-gpg/RPM-GPG-KEY-redhat-release
sslverify=1
sslclientkey=/etc/pki/rhui/content-rhel8.key
sslclientcert=/etc/pki/rhui/product/content-rhel8.crt
sslcacert=/etc/pki/rhui/cdn.redhat.com-chain.crt
Save and quit /etc/yum.repos.d/rhel-8-baseos.repo file:
:wq
Clean the yum cache:
yum clean all
List our existing repos:
yum repolist --all
Copy Repositories from server1 to server2
On server1, create a compressed archive containing the repository configuration files:
cd /etc/yum.repos.d ; tar cvfz /home/cloud_user/repos.tar.gz *.repo ; cd
On server1, copy the archive to server2:
scp /home/cloud_user/repos.tar.gz cloud_user@<second_server_private_IP>:~
On server2, as root, extract the archive in /etc/yum.repos.d:
cd /etc/yum.repos.d ; tar xvfz /home/cloud_user/repos.tar.gz ; cd
On server2, verify file transfer:
ls -al /etc/yum.repos.d/
On server2, clean the yum cache:
yum clean all
On server2, list our existing repos:
yum repolist --all
Install youtube-dl Package (from EPEL) on server1 and server2
Check if the youtube-dl package is available:
yum list --available youtube-dl
Install the RPM file from EPEL:
yum -y install youtube-dl
Verify:
yum list --installed youtube-dl
Install Default AppStream Stream/Profile for container-tools on server1 and server2
Install the default AppStream stream/profile for container-tools:
yum module install container-tools
Check for system updates, but don't install:
yum check-update | less
Quit check:
:q
Configure IP addresses for Second Network Interface on server1
Elevate to root:
sudo -i
Launch nmtui:
nmtui
Select Edit a connection.
Select your new device, ens3.
Configure IPv4 as the following:
IPv4 CONFIGURATION: <Manual> > <Show>
Addresses: server1_private_IPv4/24
Require IPv4 addressing for this connection: X
Configure IPv6 as the following:
IPv6 CONFIGURATION: <Manual> > <Show>
Addresses: server1_private_IPv6/64
Automatically connect: X
Available to all users: X
<OK>
Select Back.
Select Quit.
Validate changes:
more /etc/sysconfig/network-scripts/ifcfg-ens3
Configure Persistent Journals on server1 and server2
Elevate to root:
sudo -i
Create directory:
mkdir /var/log/journal
View contents of directory:
ls -al /var/log/journal
Clear journal:
journalctl
Force the system to log:
systemctl restart chronyd
View contents of directory:
ls -al /var/log/journal
View contents of /run/log/journal:
ls -al /run/log/journal
Managing Tuned Profiles and Individual Processes on server1
Check the currently active tuned profile:
tuned-adm active
Set a merged tuned profile using the the powersave and virtual-guest profiles:
tuned-adm profile powersave virtual-guest
Verify changes:
tuned-adm active
Start stress Process and Adjust the niceness Value to 19, Then to 10 on server1
Start a new stress process, set the niceness to 19, run it in the background:
nice -n 19 stress -c 1 &
Verify stress processes and view process IDs:
ps -ef | grep stress
View processes:
top
View process ID:
pgrep stress
Adjust niceness:
renice -n 10 <PID2>
Verify:
top
Kill the stress process:
pkill stress
Verify:
pgrep stress
Manage Scheduled Tasks on server1
Install cronie and at:
yum -y install cronie at
Verify install:
yum list --installed cronie at
Verify crond is running:
systemctl status crond
Verify atd status:
systemctl status atd
Enable atd:
systemctl enable --now atd
Verify atd status:
systemctl status atd
Add a cron job:
crontab -e
Add the following line:
* * * * *  echo `date` >> /web/html/cron.html
Save and quit:
:wq
Verify changes:
crontab -l
Verify cron job:
cat /web/html/cron.html
Add the at job:
at now +2 minutes
Insert the following:
echo "The at job ran" >> /web/html/at.html
Submit the changes by entering CTRL-D.
Verify the changes:
atq
Verify at job:
cat /web/html/at.html
Configure Time Service Clients on server1 and server2
Install the chrony and ntpstat packages:
yum -y install chrony ntpstat
Check chronyd status:
systemctl status chronyd
Enable chronyd:
systemctl enable --now chronyd
View time sources:
chronyc sources -v
Edit /etc/chrony.conf file:
vi /etc/chrony.conf
Comment out pool 2.rhel.pool.ntp.org iburst.
Configure chrony to use the following server and add the following line:
server 169.254.169.123 iburst
Save and quit:
:wq
Restart chronyd:
systemctl restart chronyd
Verify time sources:
chronyc sources -v
Managing the System Bootloader on server1
Edit the /etc/default/grub file:
vi /etc/default/grub
Set the configuration as the following:
GRUB_TIMEOUT=10
GRUB_TIMEOUT_STYLE=hidden
GRUB_DISTRIBUTOR="$(sed 's, release .*$,,g' /etc/system-release)"
GRUB_DEFAULT=saved
GRUB_DISABLE_SUBMENU=true
GRUB_TERMINAL_OUTPUT="console"
GRUB_CMDLINE_LINUX="console=ttyS0,115200n8 console=tty0 net.ifnames=0 rd.blacklist=nouveau crashkernel=auto quiet"
GRUB_DISABLE_RECOVERY="true"
GRUB_ENABABLE_BLSCFG=true
Save and quit:
:wq
Back up our current configuration:
mv /boot/grub2/grub.cfg /boot/grub2/grub.cfg.orig
mv /boot/grub2/grubenv /boot/grub2/grubenv.orig
Apply changes:
grub2-mkconfig -o /boot/grub2/grub.cfg
Verify /boot/grub2/grub.cfg one more time:
grep -E 'timeout|quiet' /boot/grub2/grub.cfg | grep -E '10|hidden|quiet'
Managing Storage on RHEL 8
Configure Persistent Storage with LVM on Top of VDO on server2
Become root:
sudo -i
Check vdo status:
systemctl status vdo
View device names:
lsblk
Create vdo volume:
vdo create --name=web_storage --device=/dev/xvdb --vdoLogicalSize=10G
Check volume:
vdostats --human-readable
Make our VDO volume a LVM physical volume:
pvcreate /dev/mapper/web_storage
Create a volume group, and add /dev/mapper/web_storage to it:
vgcreate web_vg /dev/mapper/web_storage
Create three logical volumes, web_storage_dev, web_storage_qa and web_storage_prod:
lvcreate -L 2G -n web_storage_dev web_vg
lvcreate -L 2G -n web_storage_qa web_vg
lvcreate -L 2G -n web_storage_prod web_vg
Check physical volume:
pvs
Check volume group:
vgs
Check logical volume:
lvs
Put xfs filesystems on new logical volumes:
mkfs.xfs /dev/mapper/web_vg-web_storage_dev
mkfs.xfs /dev/mapper/web_vg-web_storage_qa
mkfs.xfs /dev/mapper/web_vg-web_storage_prod
Create three mount points:
mkdir /mnt/web_storage_{dev,qa,prod}
Check /mnt directory:
ls -al /mnt
Check logical volume device names:
ls -al /dev/mapper/* | grep web
Configure three persistent mounts:
vi /etc/fstab
Add a mount entry for each logical volume at the very end of the file:
/dev/mapper/web_vg_web_storage_dev     /mnt/web_storage_dev    xfs   defaults  0 0
/dev/mapper/web_vg_web_storage_qa      /mnt/web_storage_qa     xfs   defaults  0 0
/dev/mapper/web_vg_web_storage_prod    /mnt/web_storage_prod   xfs   defaults  0 0
Save and quit:
:wq
Mount the new logical volumes:
mount -a
Check mounts:
mount | grep web
Check the stats on the new logical volumes:
df -h /mnt/web_storage*
Add Swap Space Persistently and Nondisruptive on server2
Check swap space:
swapon
View device names:
lsblk
Create an MBR partition on that device:
fdisk <first_unused_2G_device_name>
Type p to list the partitions.
Type n for new, then accept the first three defaults by pressing ENTER.
For Last sector, insert +1G.
Use p to list the partitions again.
Type t to change the partition type to swap.
Type 82 for the hex code.
Use p to list the partitions again.
Type w to write the new partition table.
Confirm newly created partition table:
fdisk -l <first_unused_2G_device_name>
Format our new swap partition and label of more_swap:
mkswap -L more_swap <first_unused_2G_device_name_partition1>
Verify device name:
blkid | grep more_swap
Add it to the /etc/fstab file:
vi /etc/fstab
Insert the following information under /swapfile swap swap defaults 0 0:
UUID=<UUID_number>  swap  swap  defaults  0 0
Save and quit:
:wq
Activate new configuration:
swapon -a
Verify:
swapon
Configure Stratis Storage Persistently on server2
Become root:
sudo -i
Install Stratis:
yum -y install stratisd stratis-cli
Enable and start Stratis:
systemctl enable --now stratisd
Check Stratis status:
systemctl status stratisd
View available devices:
lsblk
Create our Stratis pool:
stratis pool create appteam <second_unused_2G_device_name>
Verify changes:
lsblk
View block devices:
stratis blockdev
View filesystems:
stratis fs
Create stratis filesystem:
stratis fs create appteam appfs1
View changes:
ls -al /stratis/appteam/appfs1
Create a mount point:
mkdir -p /mnt/app_storage
Configure a persistent mount:
vi /etc/fstab
Insert the following information at the very end of the file:
/stratis/appteam/appfs1   /mnt/app_storage   xfs    defaults,x-systemd.requires=stratisd.service  0 0
Save and quit:
:wq
Mount it:
mount -a
Confirm changes:
mount | grep app_
df -h /mnt/app_storage
Configure the NFS server on server2
Become root:
sudo -i
Add our export to /etc/exports:
vi /etc/exports
Insert the following information: (NOTE: Use command ip addr on server1 for private IP address)
/home	<first_server_private_IP>(rw,sync,no_root_squash)
Save and quit:
:wq
Enable and start NFS server:
systemctl enable --now nfs-server
Verify status:
systemctl status nfs-server
Check NFS exports on our local system:
showmount -e
Configuring autofs to mount home directories on server1
Become root:
sudo -i
Install the autofs package:
yum -y install autofs
Create the /export/home directory:
mkdir -p /export/home
Add the mapping for the /export/home directory to /etc/auto.master:
vi /etc/auto.master
At the end of the file, above the line with +auto.master, add:
/export/home  	/etc/auto.home
Save and quit:
:wq
Edit /etc/auto.home:
vi /etc/auto.home
Add the following line: (NOTE: Use command ip addr on server2 for private IP address)
*	<second_server_private_IP>:/home/&
Save and quit:
:wq
Confirm NFS export:
showmount -e <second_server_private_IP>
Start and enable autofs service:
systemctl enable --now autofs
Check autofs status:
systemctl status autofs
On server1, change user's home directory locations to /export/home:
for i in manny moe jack marcia jan cindy; do usermod -d /export/home/$i $i; done
Confirm changes:
grep -E 'manny|moe|jack|marcia|jan|cindy' /etc/passwd
On server1, test as the user manny:
su - manny
Check directory:
pwd
Create a file:
touch file1
Create a directory:
mkdir directory1
Check our work:
ls -la
Log out manny:
exit
On server1, test as moe:
su - moe
Check directory:
pwd
Create a file:
touch file1
Create a directory:
mkdir directory1
Check our work:
ls -la
Log out moe:
exit
On server1, test as jack:
su - jack
Check directory:
pwd
Create a file:
touch file1
Create a directory:
mkdir directory1
Check our work:
ls -la
Log out jack:
exit
Confirm that the home directories are mounted via autofs on the first server:
mount | grep home
Configure a Shared Directory for Collaboration on server2
Become root:
sudo -i
Create the shared directory:
mkdir /home/dba_docs
Set group ownership to dba_staff on the shared directory:
chown -R :dba_staff /home/dba_docs
Set the permissions on the /home/dba_docs directory:
chmod 770 /home/dba_docs
Add the setgid bit for collaboration:
chmod g+s /home/dba_docs
Add an ACL entry for dba_staff:
setfacl -Rm d:g:dba_staff:rwx,g:dba_staff:rwx /home/dba_docs
Check the directory:
stat /home/dba_docs
Check ACL:
getfacl /home/dba_docs/
Test as user manny:
su - manny
Create a file as manny:
touch /home/dba_docs/mannyfile
Verify changes:
ls -la /home/dba_docs
Create a script as manny:
echo "echo You just ran manny\'s script\!" > /home/dba_docs/mannyscript.sh
Make the script executable by user and group:
chmod ug+x /home/dba_docs/mannyscript.sh
Verify changes:
ls -la /home/dba_docs
cat /home/dba_docs/mannyscript.sh
Execute the script:
/home/dba_docs/mannyscript.sh
Log out as manny:
exit
Set the sticky bit:
chmod o+t /home/dba_docs
Verify changes:
stat /home/dba_docs
Verify ACL:
getfacl /home/dba_docs/
Test as user jack:
su - jack
Check groups:
groups
Execute the script:
/home/dba_docs/mannyscript.sh
Create a file as jack:
touch /home/dba_docs/jackfile
Verify:
ls -al /home/dba_docs/
Log out as jack:
exit
Set read-only permissions for jack and cindy:
setfacl -Rm d:u:jack:r--,u:jack:r-- /home/dba_docs
setfacl -Rm d:u:cindy:r--,u:cindy:r-- /home/dba_docs
Verify changes:
getfacl /home/dba_docs
Test as cindy:
su - cindy
Check groups:
groups
Try to execute the script:
/home/dba_docs/mannyscript.sh
Try to create a file as cindy:
touch /home/dba_docs/cindyfile
Log out as cindy:
exit
View ACL on /home/dba_docs:
getfacl /home/dba_docs
Set marcia as rwx on /home/dba_docs:
setfacl -Rm d:u:marcia:rwx,u:marcia:rwx /home/dba_docs
Verify changes:
getfacl /home/dba_docs
Test as marcia:
su - marcia
Check groups:
groups
Try to create a file as marcia:
touch /home/dba_docs/marciafile
Try to execute the script:
/home/dba_docs/mannyscript.sh
Verify:
ls -al /home/dba_docs/
Log out as marcia:
exit
Use a for loop create a soft link in each user's home directory for quick and easy access to our shared directory:
for user in manny moe jack marcia jan cindy ; do echo "Adding soft link for "$user"..." ; ln -s /home/dba_docs /home/$user/dba_docs ; done
Verify changes using a for loop:
for user in manny moe jack marcia jan cindy ; do ls -al /home/$user ; done
Managing Containers Using Podman
Create a Persistent systemd Container Using Podman on server1
Verify if cloud_user: (NOTE: If not, log out and log in directly as cloud_user)
whoami
Create the ~/.config/systemd/user directory:
mkdir -p ~/.config/systemd/user
Change directory to the new directory:
cd ~/.config/systemd/user
Verify working directory:
pwd
Create directory:
mkdir ~/web_data
Create a text file in the new directory:
echo "Test data" > ~/web_data/test.txt
Verify:
cat ~/web_data/test.txt
Create a container to generate systemd unit files:
podman run -d --name web_server -p 8000:8080 -v ~/web_data:/var/www/html:Z registry.access.redhat.com/rhscl/httpd-24-rhel7
Verify running container:
podman ps -a
Test:
curl http://127.0.0.1:8000/test.txt
Verify working directory:
pwd
Generate systemd unit files:
podman generate systemd --name web_server --files --new
Verify running container:
podman ps -a
Stop web_server:
podman stop web_server
Remove web_server:
podman rm web_server
Verify running container:
podman ps -a
Configure our container to start when the system boots:
loginctl enable-linger
Verify changes:
loginctl show-user cloud_user | grep -i linger
Reload systemd to pick up the new unit:
systemctl --user daemon-reload
Enable and start the container service as the user:
systemctl --user enable --now container-web_server.service
Check the status of the container service:
systemctl --user status container-web_server
Verify running container:
podman ps -a
Final check:
curl http://127.0.0.1:8000/test.txt
Managing Security on RHEL 8
Troubleshoot SELinux Issues on server1
Become root:
sudo -i
Check Apache service status:
systemctl status httpd
Check sestatus:
sestatus
Check SELinux status:
getenforce
Temporarily disable SELinux:
setenforce 0
Verify SELinux status:
getenforce
Try to start Apache:
systemctl start httpd
Verify Apache status:
systemctl status httpd
Check Apache using curl:
curl http://127.0.0.1:85/test.html
Stop Apache:
systemctl stop httpd
Check SELinux status:
getenforce
Enable SELinux:
setenforce 1
Verify SELinux status:
getenforce
Verify usingsestatus:
sestatus
Check systemd journal:
journalctl -u httpd
Check Apache errors in the audit log:
grep httpd /var/log/audit/audit.log | less
Exit journalctl:
q
Check using ausearch:
ausearch -c 'httpd' --raw
Check /var/log/messages:
grep httpd /var/log/messages | less
Generate a local policy module:
ausearch -c 'httpd' --raw | audit2allow -M my-httpd
Activate new policy:
semodule -i my-httpd.pp
Start Apache:
systemctl start httpd
Verify Apache status:
systemctl status httpd
Check Apache, by loading test page:
curl http://127.0.0.1:85/test.html
Check SELinux file errors in file /web/html/test.html:
grep 'test.html' /var/log/messages | grep fcontext | less
Check SELinux file context on /web directory:
ls -alZ /web
Use the suggested fix from the warning message:
semanage fcontext -a -t httpd_sys_content_t "/web(/.*)?"
Apply the fix:
restorecon -Rv /web
Verify changes:
ls -alZ /web
ls -alZ /web/html
Restart Apache:
systemctl restart httpd
Check Apache, by loading test page:
curl http://127.0.0.1:85/test.html
Check /var/log/messages:
tail -50 /var/log/messages | less
Configure the Firewall on Both Servers
On server1, become root:
sudo -i
Install firewalld:
yum -y install firewalld
Enable and start firewalld:
systemctl enable --now  firewalld
Verify firewalld status:
systemctl status firewalld
On server2, become root:
sudo -i
Install firewalld:
yum -y install firewalld
Enable and start firewalld:
systemctl enable --now  firewalld
Verify firewalld status:
systemctl status firewalld
On server1, view firewall configuration:
firewall-cmd --list-all
Add TCP port 85 configuration:
firewall-cmd --add-port=85/tcp --permanent
Add TCP port 8000 configuration:
firewall-cmd --add-port=8000/tcp --permanent
Reload the firewall to add changes:
firewall-cmd --reload
Verify firewall configuration:
firewall-cmd --list-all
On server2, view firewall configuration:
firewall-cmd --list-all
Add NFS:
firewall-cmd --add-service=nfs --permanent
Add NFS3:
firewall-cmd --add-service=nfs3 --permanent
Add rpc-bind:
firewall-cmd --add-service=rpc-bind --permanent
Add mountd:
firewall-cmd --add-service=mountd --permanent
Reload the firewall to add changes:
firewall-cmd --reload
Verify firewall configuration:
firewall-cmd --list-all
On server1, view IP addresses:
ip addr
On server2, use nmap to view open services and ports:
nmap -A <server1_private_IP>
On server2, view IP addresses:
ip addr
On server1, use nmap to view open services and ports:
nmap -A <server2_private_IP>
Now you should be able to reboot to test persistence on both servers. Check services, containers, swap, mounts are persistent and able to survive a reboot.
systemctl reboot
Conclusion
Congratulations — you've completed this hands-on lab!