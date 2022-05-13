 
# Spis treści

1. [Oreilly](#Oreilly)
    - [Oreilly Practice Exam A](#RHCSA-Practice-Exam-A)  
    - [Oreilly Practice Exam B](#RHCSA-Practice-Exam-B)  
    - [Oreilly Practice Exam C](#RHCSA-Practice-Exam-C)  
    - [Oreilly Practice Exam D](#RHCSA-Practice-Exam-D)  
2. [Examptopics](#Examptopics)   
3. [vander](#vander)
	- [RHCSA vander 1](#RHCSA-Practice-Exam-1)
	- [RHCSA vander 2](#RHCSA-Practice-Exam-2)

---

[Odpowiedzi](#odpowiedzi)

1. [Oreilly odpowiedzi](#Oreilly---odpowiedzi)
	1. [Exam A](#Exam-A---odpowiedzi)  
	2. [Exam B](#Exam-B---odpowiedzi)  
	3. [Exam C](#Exam-C---odpowiedzi)  
	4. [Exam D](#Exam-D---odpowiedzi)  
2. [vander odpowiedzi](#vander---odpowiedzi)
	1. [RHCSA vander 1](#vander-Exam-1---odpowiedzi)
	2. [RHCSA vander 2](#vander-Exam-2---odpowiedzi)
---

# Oreilly
[Spis treści](#spis-treści)

**Here are some tips to ensure your exam starts with a clean environment:**  
    - You do not need any external servers or resources.  
    - Do not register or connect to any external repositories.  
    - Install a new VM according to the instructions in each practice exam.  
    - No sample solutions are provided for these practice exams. On the real exam, you need to be able to verify the solutions for yourself as well.  
    - You should be able to complete each exam within two hours.  

## RHCSA Practice Exam A
[Spis treści](#spis-treści)

[Oreilly Practice Exam A](https://learning.oreilly.com/library/view/red-hat-rhcsa/9780137341641/exama.xhtml#exama)

Install a RHEL 8 or CentOS 8 virtual machine that meets the following requirements:
- 2 GB of RAM
- 20 GB of disk space using default partitioning
- One additional 20-GB disk that does not have partitions installed
- Server with GUI installation pattern


1. Create user **student** with password **password**, and user root with password **password**.

2. Configure your system to automatically loop-mount the ISO of the installation disk on the directory **/repo**. Configure your system to remove this loop-mounted ISO as the only repository that is used for installation. Do not register your system with subscription-manager, and remove all reference to external repositories that may already exist.

3. Reboot your server. Assume that you don’t know the root password, and use the appropriate mode to enter a root shell that doesn’t require a password. Set the root password to mypassword.

4. Set default values for new users. Set the default password validity to 90 days, and set the first UID that is used for new users to 2000.

5. Create users **edwin** and **santos** and make them members of the group livingopensource as a secondary group membership. Also, create users serene and alex and make them members of the group operations as a secondary group.

6. Create shared group directories **/groups/livingopensource** and **/groups/operations**, and make sure the groups meet the following requirements:
    - Members of the group livingopensource have full access to their directory.
    - Members of the group operations have full access to their directory.
    - New files that are created in the group directory are group owned by the group owner of the parent directory.
    - Others have no access to the group directories.
    - Members of the group operations have read access to the directory/groups/livingopensource.

8. Create a 2-GiB volume group, using 8-MiB physical extents. In this volume group, create a 500-MiB logical volume with the name mydata, and mount it persistently on the directory **/mydata**.

9. Find all files that are owned by user edwin and copy them to the directory/rootedwinfiles.

10. Schedule a task that runs the command touch /etc/motd every day from Monday through Friday at 2 a.m.

11. Add a new 10-GiB virtual disk to your virtual machine. On this disk, add a VDO volume with a size of 20 GiB and mount it persistently.

12. Create user **bob** and set this user’s shell so that only this user can change the password.

13. Install the vsftpd service and ensure that it is started automatically at reboot.

14. Create a container that runs the rsyslog service. This container should be configured to write log files persistently to the directory /var/log/logcontainer/ on the host operating system. Run this container with the same user account that the rsyslog service normally uses.

15. Configure this container such that it is automatically started on system boot as a system user service.




## RHCSA Practice Exam B
[Spis treści](#spis-treści)

[Oreilly Practice Exam B](https://learning.oreilly.com/library/view/red-hat-rhcsa/9780137341641/examb.xhtml#examb)

Install a RHEL 8 or CentOS 8 virtual machine that meets the following requirements:
- 2 GB of RAM
- 20 GB of disk space using default partitioning
- One additional 20-GB disk that does not have partitions installed
- Server with GUI installation pattern


1. Create user **student** with password **password**, and user root with password **password**.

2. Configure your system to automatically loop-mount the ISO of the installation disk on the directory **/repo**. Configure your system to remove this loop-mounted ISO as the only repository that is used for installation. Do not register your system with subscription-manager, and remove all reference to external repositories that may already exist.

3. Create a 1-GB XFS partition on /dev/sdb. Mount it persistently on the directory **/mydata**, using the label mylabel.

4. Set default values for new users. Ensure that an empty file with the name NEWFILE is copied to the home directory of each new user that is created.

5. Create users laura and linda and make them members of the group livingopensource as a secondary group membership. Also, create users lisa and lori and make them members of the group operations as a secondary group.

6. Create shared group directories /groups/livingopensource and /groups/operations and make sure these groups meet the following requirements:
    - Members of the group livingopensource have full access to their directory.
    - Members of the group operations have full access to their directory.
    - Users should be allowed to delete only their own files.
    - Others should have no access to any of the directories.

7. Create a 2-GiB swap partition and mount it persistently.

8. Resize the LVM logical volume that contains the root file system and add 1 GiB.

9. Set your server to use the recommended tuned profile.

10. Create user vicky with the custom UID 2008.

11. Configure your server to synchronize time with myserver.example.com. (Note that this server does not have to exist.)

12. Install a web server and ensure that it is started automatically.


## RHCSA Practice Exam C
[Spis treści](#spis-treści)

[Oreilly Practice Exam C](https://learning.oreilly.com/library/view/red-hat-rhcsa/9780137341641/examc.xhtml#examc)

Install a RHEL 8 or CentOS 8 virtual machine that meets the following requirements:
- 2 GB of RAM
- 20 GB of disk space using default partitioning
- One additional 20-GB disk that does not have partitions installed
- Server with GUI installation pattern



1. Create user **student** with password **password**, and user root with password **password**.

2. Configure your system to automatically loop-mount the ISO of the installation disk on the directory **/repo**. Configure your system to remove this loop-mounted ISO as the only repository that is used for installation. Do not register your system with subscription-manager, and remove all reference to external repositories that may already exist.

3. Reboot your server. Assume that you don’t know the root password, and use the appropriate mode to enter a root shell that doesn’t require a password. Set the root password to mypassword.

4. Set default values for new users. Make sure that any new user password has a length of at least six characters and must be used for at least three days before it can be reset.

5. Create users **edwin** and **santos** and make them members of the group sales as a secondary group membership. Also, create users serene and alex and make them members of the group account as a secondary group.

6. Create shared group directories /groups/sales and /groups/account, and make sure these groups meet the following requirements:
    - Members of the group sales have full access to their directory.
    - Members of the group account have full access to their directory.
    - Users have permissions to delete only their own files, but alex is the general manager, so user alex has access to delete all users’ files.

7. Create a 4-GiB volume group, using a physical extent size of 2 MiB. In this volume group, create a 1-GiB logical volume with the name myfiles and mount it persistently on /myfiles.

8. Create a group sysadmins. Make users **edwin** and **santos** members of this group and ensure that all members of this group can run all administrative commands using sudo.

9. Optimize your server with the appropriate profile that optimizes throughput.

10. Add a new disk to your virtual machine with a size of 10 GiB. On this disk, create a VDO volume with a size of 50 GiB and mount it persistently.

11. Configure your server to synchronize time with serverabc.example.com, where serverabc is an alias to myserver.example.com. Note that this server does not have to exist to accomplish this exercise.

12. Configure a web server to use the nondefault document root /webfiles. In this directory, create a file index.html that has the contents hello world and then test that it works.

13. Configure your system to automatically start a mariadb container. This container should expose its services at port 3306 and use the directory /var/mariadb-container on the host for persistent storage of files it writes to the /var directory.

14. Configure your system such that the container created in step 14 is automatically started as a Systemd user container.





## RHCSA Practice Exam D
[Spis treści](#spis-treści)

[# RHCSA Practice Exam D](https://learning.oreilly.com/library/view/red-hat-rhcsa/9780137341641/examd.xhtml#examd)


Install a RHEL 8 or CentOS 8 virtual machine that meets the following requirements:
- 2 GB of RAM
- 20 GB of disk space using default partitioning
- One additional 20-GB disk that does not have partitions installed
- Server with GUI installation pattern


1. Create user **student** with password **password**, and user root with password **password**.

2. Configure your system to automatically loop-mount the ISO of the installation disk on the directory **/repo**. Configure your system to remove this loop-mounted ISO as the only repository that is used for installation. Do not register your system with subscription-manager, and remove all reference to external repositories that may already exist.

3. Create a 500-MiB partition on your second hard disk, and format it with the Ext4 file system. Mount it persistently on the directory **/mydata**, using the label **mydata**.

4. Set default values for new users. A user should get a warning three days before expiration of the current password. Also, new passwords should have a maximum lifetime of 120 days.

5. Create users **edwin** and **santos** and make them members of the group livingopensource as a secondary group membership. Also, create users serene and alex and make them members of the group operations as a secondary group.

6. Create shared group directories /groups/livingopensource and /groups/operations, and make sure the groups meet the following requirements:
    - Members of the group livingopensource have full access to their directory.
    - Members of the group operations have full access to their directory.
    - Others has no access to any of the directories.
    - Alex is general manager, so user alex has read access to all files in both directories and has permissions to delete all files that are created in both directories.

7. Create a 1-GiB swap partition and mount it persistently.

8. Find all files that have the SUID permission set, and write the result to the file /root/suidfiles.

9. Create a 1-GiB LVM volume group. In this volume group, create a 512-MiB swap volume and mount it persistently.

10. Add a 10-GiB disk to your virtual machine. On this disk, create a Stratis pool and volume. Use the name stratisvol for the volume, and mount it persistently on the directory /stratis.

11. Install a web server and configure it to listen on port 8080.

12. Create a configuration that allows user edwin to run all administrative commands using sudo.




# Examptopics
[Spis treści](#spis-treści)

Configure your Host Name, IP Address, Gateway and DNS. 
Host name: station.domain40.example.com 
/etc/sysconfig/network 
hostname=abc.com hostname abc.com IP Address:172.24.40.40/24 - Gateway172.24.40.1 - DNS:172.24.40.1 -

Create a catalog under /home named admins. Its respective group is requested to be the admin group. The group users could read and write, while other users are not allowed to access it. The files created by users from the same group should also be the admin group.

Configure a task: plan to run echo hello command at 14:23 every day.


Find the files owned by harry, and copy it to catalog: /opt/dir


Find the rows that contain abcde from file /etc/testfile, and write it to the file/tmp/testfile, and the sequence is requested as the same as /etc/testfile.


Install a FTP server, and request to anonymous download from /var/ftp/pub catalog. (it needs you to configure yum direct to the already existing file server.)


Configure a HTTP server, which can be accessed through http://station.domain40.example.com. Please download the released page from http://ip/dir/example.html.


Configure autofs to make sure after login successfully, it has the home directory autofs, which is shared as /rhome/ldapuser40 at the ip: 172.24.40.10. and it also requires that, other ldap users can use the home directory normally.


- Configure the system synchronous as 172.24.40.10.
```bash
# FOR RHEL8:
sudo yum -y install chrony
sudo vi /etc/chrony.conf
server 192.168.25.3
sudo timedatectl set-ntp true
sudo systemctl enable --now chronyd
```


- Create a volume group, and set 16M as a extends. And divided a volume group containing 50 extends on volume group lv, make it as ext4 file system, and mounted automatically under /mnt/data.
```bash
# assume that /dev/sdb2 and /dev/sdb3 were created (lsblk to verify it)

pvcreate /dev/sdb{2,3}
pvdisplay /dev/sdb* (verify)

vgcreate VG01 --physicalextentsize 16M /dev/sdb{2,3}
vgdisplay /dev/VG01 (verify)

lvcreate --extents 50 --name LV01 VG01
lvdisplay /dev/VG01 (verify)

blkid /dev/VG01/LV01 (get UUID=XXX-XX-XX)
mkdir -p /mnt/data
echo "UUID=XXX-XX-XX /mnt/data ext4 defaults 0 0" | tee -a /etc/fstab
mount -a
```


- Upgrading the kernel as 2.6.36.7.1, and configure the system to Start the default kernel, keep the old kernel available.
```bash
# To update Kernel:
rpm -ivh [kernel.rmp] --> Install a rpm package in verbose mode
# OR
yum install kernel --> (If you're using repositories)

# It's important to know that this doesn't replace the actual kernel. It is installed along the actual kernel and you can select any available kernel to boot the system in case of troubleshooting.
# Also, the system onlny saves a maximum of 4 kernels. If you already have 4, and install a 5th kernel, this one will replace the oldest kernel.
# -----------
# To set a default kernel:
# - We can use grubby command tool.
grubby --default-kernel --> Get default kernel (It's probably that the latest installed be selected)
grubby --info=ALL | grep ^kernel --> This command list all kernel paths for the available kernels.
grubby --set-default=[kernel path obtained from the above command]

# Reboot and verify
uname -r --> Get the loaded kernel
```


- Create a 512M partition, make it as ext4 file system, mounted automatically under /mnt/data and which take effect automatically at boot-start.
```bash
#fdisk -l (to check for empty disk)
#fdisk /dev/sdd (format disk in question)
#n (new partition)
#p (for primary)
#Enter (use the first sector by default)
#+size 512M (to specify the size)
#Enter
#w (to write the changes)
#fdisk -l /dev/sdd1 (to verify partition has been created)
#mkfs.ext4 /dev/sdd1 (to format the partition with ext4 file system)
#mkdir /mnt/data (to create the mount point)
#mount /dev/sdd1 (mount the partition)
#vi /etc/fstab (to configure auto mount after each boot)
Press Shift G to go to the last line and press O to start in new line in Insert mode. Enter the following (ensure you press TAB for each part of the entry):
/dev/sdd1 /mnt/data /ext4 defaults 0 0
Exit out of the Insert mode and type: :wq!
```


- Create a volume group, and set 8M as a extends. Divided a volume group containing 50 extends on volume group lv (lvshare), make it as ext4 file system, and mounted automatically under /mnt/data. And the size of the floating range should set between 380M and 400M.

```bash
-- lets say we are going to work on /dev/vda3 ,
make sure this disk has no mount point,if any than unmount them
ex. umount /mnt/data

partprobe
vgcreate -s 8M vg1 /dev/vda3
lvcreate -n lvshare -l 50 vg1
mkfs.ext4 /dev/vg1/lvshare
mkdir -p /mnt/data
vim /etc/fstab
/dev/vg1/lvshare /mnt/data ext4 defaults 0 0
mount -a
partprobe
df -h

```


- Add admin group and set gid=600 -
```bash
groupadd -g 600 admin
```

- Add users: user2, user3. The Additional group of the two users: user2, user3 is the admin group Password: redhat
```bash
useradd -G admin user2
useradd -G admin user3
echo “redhat” | passwd --stdin user2
echo “redhat” | passwd --stdin user3
```


- Copy /etc/fstab to /var/tmp name admin, the user1 could read, write and modify it, while user2 without any permission.
```bash
useradd -M user1
useradd -M user2
cp /etc/fstab /vat/tmp/
setfacl -m u:user1:rw- /var/tmp/fstab
setfacl -m u:user2:--- /vat/tmp/fstab
````


- Configure a task: plan to run echo "file" command at 14:23 every day.
```bash
cat <<EOF> /etc/cron.d/echo_file
23 14 * * * /usr/bin/echo 'file'
EOF
```

- Configure a default software repository for your system. One YUM has already provided to configure your system on http://server.domain11.example.com/pub/ x86_64/Server, and can be used normally.
```bash
dnf config-manager --add-repo=http://server.domain11.example.com/pub/ x86_64/Server/BaseOs

vi local-rhel8.repo
# add gpgcheck=0 in the config file

[LocalRepo_BaseOS]
name=LocalRepo_BaseOS
metadata_expire=-1
enabled=1
gpgcheck=0
baseurl=http://server.domain11.example.com/pub/ x86_64/Server/BaseOS/

```

- Adjust the size of the Logical Volume. Adjust the size of the vo Logical Volume, its file system size should be 290M. Make sure that the content of this system is complete. Note: the partition size is rarely accurate to the same size as required, so in the range 270M to 320M is acceptable.
```bash
# rhel8
umount /dev/mapper/my_vol2-lvshare /mnt/data
lvreduce -r -L 290M /dev/my_vol2/lvshare
lsblk
mount -a
```

- Configure /var/tmp/fstab Permission. Copy the file /etc/fstab to /var/tmp/fstab. Configure var/tmp/fstab permissions as the following: Owner of the file /var/tmp/fstab is Root, belongs to group root File /var/tmp/fstab cannot be executed by any user User natasha can read and write /var/tmp/fstab User harry cannot read and write /var/tmp/fstab All other users (present and future) can read var/tmp/fstab.
```bash
cp /etc/fstab /var/tmp/
/var/tmp/fstab view the owner setfacl -m u:natasha:rw- /var/tmp/fstab setfacl -m u:haryy:--- /var/tmp/fstab
Use getfacl /var/tmp/fstab to view permissions
```


- Please open the ip_forward, and take effect permanently.
```bash

```


- Open kmcrl value of 5 , and can verify in /proc/ cmdline
```bash
# this is not found in rhcsa 2021

grubby --update-kernel=ALL --args="kmcrl=5"
cat /boot/grub2/grubenv
systemctl reboot
cat /proc/cmdline

```


- Configure iptables, there are two domains in the network, the address of local domain is 172.24.0.0/16 other domain is 172.25.0.0/16, now refuse domain 172.25.0.0/16 to access the server.
```bash
Use fdisk /dev/hda ->To create new partition.

Type n-> For New partition -
It will ask for Logical or Primary Partitions. Press l for logical.
It will ask for the Starting Cylinder: Use the Default by pressing Enter Key.
Type the Size: +100M ->You can Specify either Last cylinder of Size here.
Press P to verify the partitions lists and remember the partitions name. Default System ID is 83 that means Linux Native.
Type t to change the System ID of partition.

Type Partition Number -
Type 82 that means Linux Swap.
Press w to write on partitions table.
Either Reboot or use partprobe command.
mkswap /dev/hda? ->To create Swap File system on partition.
swapon /dev/hda? ->To enable the Swap space from partition.
free -m ->Verify Either Swap is enabled or not.
vi /etc/fstab/dev/hda? swap swap defaults 0 0
Reboot the System and verify that swap is automatically enabled or not.


In RHEL8 for fstab configuration is not more recommended to use absolute patch to the device like /dev/sda7.
The recommendation is to use the UUID identifier instead.
To get the swap or any other filesystem's UUID use the command blkid.
This will show you all filesystems UUIDs in example:
/dev/sda7: UUID="361ed5b5-872a-4e49-ba70-91efb28b2bb4" TYPE="swap" PARTUUID="caa5e8f6-01"

Copy the section UUID="361ed5b5-872a-4e49-ba70-91efb28b2bb4" and use it in fstab as follows.
UUID="361ed5b5-872a-4e49-ba70-91efb28b2bb4" swap swap defaults 0 0
```


There are two different networks, 192.168.0.0/24 and 192.168.1.0/24. Your System is in 192.168.0.0/24 Network. One RHEL6 Installed System is going to use as a Router. All required configuration is already done on Linux Server. Where 192.168.0.254 and 192.168.1.254 IP Address are assigned on that Server. How will make successfully ping to 192.168.1.0/24 Network's Host?



Make a swap partition having 100MB. Make Automatically Usable at System Boot Time.



One Logical Volume is created named as myvol under vo volume group and is mounted. The Initial Size of that Logical Volume is 400MB. Make successfully that the size of Logical Volume 200MB without losing any data. The size of logical volume 200MB to 210MB will be acceptable.



We are working on /data initially the size is 2GB. The /dev/test0/lvtestvolume is mount on /data. Now you required more space on /data but you already added all disks belong to physical volume. You saw that you have unallocated space around 5 GB on your harddisk. Increase the size of lvtestvolume by 5GB.


- Make on data that only the user owner and group owner member can fully access.
```bash
chmod 770 /data
Verify using : ls -ld /data Preview should be like:
drwxrwx--- 2 root sysadmin 4096 Mar 16 18:08 /data
To change the permission on directory we use the chmod command.
According to the question that only the owner user (root) and group member (sysadmin) can fully access the directory so: chmod 770 /data
```


- Who ever creates the files/directories on a data group owner should automatically be in the same group owner as data.
```bash
1. chmod g+s /data
2. Verify using: ls -ld /data
Permission should be like this: drwxrws--- 2 root sysadmin 4096 Mar 16 18:08 /data
If SGID bit is set on directory then who every users creates the files on directory group owner automatically the owner of parent directory. To set the SGID bit: chmod g+s directory To Remove the SGID bit: chmod g-s directory
```


- Your System is going to use as a Router for two networks. One Network is 192.168.0.0/24 and Another Network is 192.168.1.0/24. Both network's IP address has assigned. How will you forward the packets from one network to another network?
```bash


```


- /data Directory is shared from the server1.example.com server. Mount the shared directory that:
```bash
# In RHEL8 and because de request is not with autofs, we can proceed in this way:
mount server1.example.com server:/data /mnt

1. vi /etc/auto.master
/mnt /etc /auto.misc --timeout=50
vi /etc/auto.misc
data -rw,soft,intr server1.example.com:/data
service autofs restart
chkconfig autofs on
When you mount the other filesystem, you should unmount the mounted filesystem, Automount feature of linux helps to mount at access time and after certain seconds, when user unaccess the mounted directory, automatically unmount the filesystem.
/etc/auto.master is the master configuration file for autofs service. When you start the service, it reads the mount point as defined in /etc/auto.master.

```


- You are new System Administrator and from now you are going to handle the system and your main task is Network monitoring, Backup and Restore. But you don't know the root password. Change the root password to redhat and login in default Runlevel.
```bash
# In RHEL8
- reboot the system
- press "e" letter
- Add "rd.break" at the end of de line thet begening with "Linux" in grub menu
- ctrl + x
- # mount -o remount,rw /sysroot
- # chroot /sysroot
- # passwd
- #  touch /.autorelabel
- # exit
- # logout
```



- You are a System administrator. Using Log files very easy to monitor the system. Now there are 50 servers running as Mail, Web, Proxy, DNS services etc. You want to centralize the logs from all servers into on LOG Server. How will you configure the LOG Server to accept logs from remote host?
```bash
By default, system accept the logs only generated from local host. To accept the Log from other host configure: vi /etc/sysconfig/syslog SYSLOGD_OPTIONS="-m 0 -r"

Where -
-m 0 disables 'MARK' messages.
-r enables logging from remote machines
-x disables DNS lookups on messages received with -r
service syslog restart
```



- Create a Shared Directory. Create a shared directory /home/admins, make it has the following characteristics: /home/admins belongs to group adminuser This directory can be read and written by members of group adminuser Any files created in /home/ admin, group automatically set as adminuser.
```bash
mkdir -p /home/admins
groupadd adminuser
chown :adminuser /home/admins
setfacl -m g:adminuser:rwx /home/admins
chmod g+s /home/admins/
```


- Configure NTP. Configure NTP service, Synchronize the server time, NTP server: classroom.example.com
```bash
yum -y install chrony
systemctl enable --now chronyd
vim etc/chrony.conf
# (change on server classroom.example.com iburs)
systemctl reload chronyd
timedatectl set-ntp true
```



- Configure a user account. Create a user iar uid is 3400. Password is redhat ï¼Œ
```bash
useradd -u 3400 iar
id iar
passwd iar
```


- Search files. Find out files owned by jack, and copy them to directory /root/findresults
```bash
mkdir -p /root/findresults
find / -user jack -type f -exec cp -avrf {} /root/findresults/ \;
ls -l /root/findresults
```


- Search a String - Find out all the columns that contains the string seismic within /usr/share/dict/words, then copy all these columns to /root/lines.tx in original order, there is no blank line, all columns must be the accurate copy of the original columns.
```bash
grep seismic /usr/share/dict/words > /root/lines.txt
```


- Create a backup - Create a backup file named /root/backup.tar.bz2, contains the content of /usr/local, tar must use bzip2 to compress.
```bash
# Simple to understand and execute,

[root@station ~]# yum install bzip2
[root@station ~]# tar -cvf /root/backup.tar /usr/local/
[root@station ~]# du -sh /root/backup.tar
20K /root/backup.tar
[root@station ~]# bzip2 /root/backup.tar
[root@station ~]# du -sh /root/backup.tar.bz2
4.0K /root/backup.tar.bz2
[root@station ~]#
```


- Create a logical volume - Create a new logical volume as required: Name the logical volume as database, belongs to datastore of the volume group, size is 50 PE. Expansion size of each volume in volume group datastore is 16MB. Use ext3 to format this new logical volume, this logical volume should automatically mount to /mnt/database
```bash
# vgcreate -s 16M datastore /dev/sdxx
# lvcreate -l 50 -n database datastore
# lvs
# mkdir /mnt/database
# mkfs.ext3 /dev/datastore/database
# echo "/dev/datastore/database /mnt/database/ ext3 defaults 0 0" >> /etc/fstab
# mount -a
# df -h



fdisk -cu /dev/vda// Create a 1G partition, modified when needed partx ""a /dev/vda pvcreate /dev/vdax vgcreate datastore /dev/vdax ""s 16M lvcreate"" l 50 ""n database datastore mkfs.ext3 /dev/datastore/database mkdir /mnt/database mount /dev/datastore/database /mnt/database/ df ""Th vi /etc/fstab
/dev/datastore /database /mnt/database/ ext3 defaults 0 0 mount ""a
Restart and check all the questions requirements.
```

- Your System is configured in 192.168.0.0/24 Network and your nameserver is 192.168.0.254. Make successfully resolve to server1.example.com.
```bash
nameserver is specified in question,
1. Vi /etc/resolv.conf
nameserver 192.168.0.254
2. host server1.example.com
```

- Some users home directory is shared from your system. Using showmount -e localhost command, the shared directory is not shown. Make access the shared users home directory.
```bash
NFS Server:
- dnf install nfs-utils libnfsidmap
- systemctl enable rpcbind & nfs-server
- systemctl start rpcbind, nfs-server, rpc-statd, nfs-idmapd
- vi /etc/exports
- add /home/user 192.168.x.x (rw,sync,no_root_squash)
- exportfs -rv
- showmount -e
- Optional: may need to enable the rule on firewalld or stop it altogether for it to work on remote clients

NFS Client:
- dnf install nfs-utils rpcbind
- systemctl start rpcbind
- ps -ef | egrep “firewalld:iptables” (may need to stop these two services, or add appropriate rules for mounting to work across server and client)
- Create a mount point
- Mount 192.168.x.x:/dir /mountpoint
```





Verify the File whether Shared or not ? : cat /etc/exports Start the nfs service: service nfs start Start the portmap service: service portmap start Make automatically start the nfs service on next reboot: chkconfig nfs on Make automatically start the portmap service on next reboot: chkconfig portmap on Verify either sharing or not: showmount -e localhost Check that default firewall is running on system? If running flush the iptables using iptables -F and stop the iptables service.



Successfully resolve to server1.example.com where your DNS server is 172.24.254.254.



Who ever creates the files/directories on archive group owner should be automatically should be the same group owner of archive.



Make on /archive directory that only the user owner and group owner member can fully access.



SELinux must run in force mode.



In the system, mounted the iso image /root/examine.iso to/mnt/iso directory. And enable automatically mount (permanent mount) after restart system.



1. Find all sizes of 10k file or directory under the /etc directory, and copy to /tmp/findfiles directory. 2. Find all the files or directories with Lucy as the owner, and copy to /tmp/findfiles directory.



There is a local logical volumes in your system, named with common and belong to VGSRV volume group, mount to the /common directory. The definition of size is 128 MB. Requirement: Extend the logical volume to 190 MB without any loss of data. The size is allowed between 160-160 MB after extending.




Create a swap space, set the size is 600 MB, and make it be mounted automatically after rebooting the system (permanent mount).


According the following requirements to create a local directory /common/admin. This directory has admin group. This directory has read, write and execute permissions for all admin group members. Other groups and users don't have any permissions. All the documents or directories created in the/common/admin are automatically inherit the admin group.



User mary must configure a task. Requirement: The local time at 14:23 every day echo "Hello World.".



- Copy /etc/fstab document to /var/TMP directory. According the following requirements to configure the permission of this document. ? The owner of this document must be root. ? This document belongs to root group. ? User mary have read and write permissions for this document. ? User alice have read and execute permissions for this document. ? Create user named bob, set uid is 1000. Bob have read and write permissions for this document. ? All users has read permission for this document in the system.




Configure your web services, download from http://instructor.example.com/pub/serverX.html And the services must be still running after system rebooting.




Download the document from ftp://instructor.example.com/pub/testfile, find all lines containing [abcde] and redirect to /MNT/answer document, then rearrange the order according the original content.




SELinux must be running in the Enforcing mode.



Create the following users, groups, and group memberships: A group named adminuser. A user natasha who belongs to adminuser as a secondary group A user harry who also belongs to adminuser as a secondary group. A user sarah who does not have access to an interactive shell on the system, and who is not a member of adminuser, natasha, harry, and sarah should all have the password of redhat.



Set cronjob for user natasha to do /bin/echo hiya at 14:23.


Install the appropriate kernel update from http://server.domain11.example.com/pub/updates. The following criteria must also be met: The updated kernel is the default kernel when the system is rebooted The original kernel remains available and bootable on the system



Locate all the files owned by ira and copy them to the / root/findresults directory.


Find all lines in the file /usr/share/dict/words that contain the string seismic. Put a copy of all these lines in their original order in the file /root/wordlist. /root/wordlist should contain no empty lines and all lines must be exact copies of the original lines in /usr/share/dict/words.


Create a backup file named /root/backup.tar.bz2, which contains the contents of /usr/local, bar must use the bzip2 compression.


Configure your Host Name, IP Address, Gateway and DNS. Host name: station.domain40.example.com /etc/sysconfig/network hostname=abc.com hostname abc.com IP Address:172.24.40.40/24 - Gateway172.24.40.1 - DNS:172.24.40.1 -


Add 3 users: harry, natasha, tom. The requirements: The Additional group of the two users: harry, Natasha is the admin group. The user: tom's login shell should be non-interactive.


Create a catalog under /home named admins. Its respective group is requested to be the admin group. The group users could read and write, while other users are not allowed to access it. The files created by users from the same group should also be the admin group.


Find the files owned by harry, and copy it to catalog: /opt/dir


Create a user named alex, and the user id should be 1234, and the password should be alex111.


echo alex111|passwd -stdin alex


Configure a HTTP server, which can be accessed through http://station.domain40.example.com. Please download the released page from http://ip/dir/example.html.


Part 2 (on Node2 Server) Task 2 [Installing and Updating Software Packages] Configure your system to use this location as a default repository: http://utility.domain15.example.com/BaseOS http://utility.domain15.example.com/AppStream Also configure your GPG key to use this location http://utility.domain15.example.com/RPM-GPG-KEY-redhat-release


Part 1 (on Node1 Server) Task 10 [Configuring NTP/Time Synchronization] Configure your system so that it is an NTP client of utility.domain15.example.com The system time should be set to your (or nearest to you) timezone and ensure NTP sync is configured



SELinux must be running in the Enforcing mode.


The system ldap.example.com provides an LDAP authentication service. Your system should bind to this service as follows: The base DN for the authentication service is dc=domain11, dc=example, dc=com LDAP is used to provide both account information and authentication information. The connection should be encrypted using the certificate at http://host.domain11.example.com/pub/domain11.crt When properly configured, ldapuserX should be able to log into your system, but will not have a home directory until you have completed the autofs requirement. Username: ldapuser11 Password: password



Create the user named eric and deny to interactive login.


Find all lines in the file /usr/share/dict/words that contain the string seismic. Put a copy of all these lines in their original order in the file /root/wordlist. /root/wordlist should contain no empty lines and all lines must be exact copies of the original lines in /usr/share/dict/words.


Part 1 (on Node1 Server) Task 14 [Managing SELinux Security] You will configure a web server running on your system serving content using a non-standard port (82)


Create a 512M partition, make it as ext4 file system, mounted automatically under /mnt/data and which take effect automatically at boot-start.


Locate all the files owned by ira and copy them to the / root/findresults directory.



Part 2 (on Node2 Server) Task 1 [Controlling the Boot Process] Interrupt the boot process and reset the root password. Change it to kexdrams to gain access to the system








https://learning.oreilly.com/learning-paths/red-hat-certified/8204091500000000003/9780136552512-/ch01.xhtml


# Vander

# RHCSA Practice Exam 1
[Spis treści](#spis-treści)

[Oreily Vander 1](https://learning.oreilly.com/learning-paths/red-hat-certified/8204091500000000003/9780136552512-/ch01.xhtml)

RHCSA Practice Exam 1

Welcome to the first practice exam for the Red Hat Certified System Administrator (RHCSA) Complete Video Course, Third Edition. This exam should take you one hour.
This test exam requires the following setup:
- A cleanly installed RHEL 8 virtual machine with the name server3.
- Unless specifically mentioned, all tasks described next should be performed on the virtual machine.

	- Bring down the virtual machine you have pre-installed and, in the KVM software, add an additional 5GiB hard disk to the virtual machine.
	
	- A repository is available at http://rhatcert.com/repo. Configure your server3 to use this repository and disable usage of any other repositories.
	
	- Create four users: bill, bob, betty, and belinda. Set their passwords to expire after 120 days and make sure they get a home directory in /home/users. (This means that, for instance, bill has /home/users/bill as his home directory.)
	
	- Create two groups: consultants and trainers. Make bill and bob members of the group consultants without overwriting any of their current group memberships. Make belinda and betty members of the group trainers without changing any of their current group memberships.
	
	- Create a shared group environment that meets the following requirements:
		- [ ] The group consultants has full read/write access to the directory /groups/consultants.
		- [ ] The group trainers has full read/write access to the directory /groups/consultants.
		- [ ] bill is head of the consultants department and should be able to remove files that have been created by any user in /groups/consultants. Any other members of the group consultants should have no rights to remove files they haven't created themselves.
		- [ ] betty is head of the trainers department and should be able to remove files that have been created by any user in /groups/trainers. Any other members of the group trainers should have no rights to remove files they haven't created themselves.
		- [ ] All new files created in /groups/trainers should automatically get group-owned by the group trainers.
		- [ ] All new files created in /groups/consultants should automatically get group-owned by the group consultants.
		- [ ] Members of the group consultants should be able to read files in /groups/trainers.
	
	- Create an LVM logical volume with the name lvfiles. This volume should have a size of 1GiB, and it should be allocated from a volume group with the name vgfiles. Format this volume with the ext4 file system and mount it persistently on the directory /files.
	
	- Enable the performance profile that optimizes your server for best throughput.
	
	- Create a scheduled job that will send the message "hello" to the system-logging mechanism at the top of each hour.
	
	- Make the systemd journal persistent.












# RHCSA Practice Exam 2
[Spis treści](#spis-treści)

[Oreily Vander 2](https://learning.oreilly.com/learning-paths/red-hat-certified/8204091500000000003/9780136552512-/ch02.xhtml)

Welcome to the second practice exam for the Red Hat Certified System Administrator (RHCSA) Complete Video Course, Third Edition. This exam should take you two hours.  
Create a virtual machine with the name server4. Make sure it meets the following requirements:  
- A 20GiB hard disk is available.

- The root password is set to "password".

- The user "student" is created, with the password "password".

- Use custom partitioning to create a 1GiB /boot partition and a 12GiB / partition.
	
	- Configure your installation disk as the default repository. Make sure to disable all other repositories.
	
	- Configure your system to clean up /tmp files every hour.
	
	- Add two 10GiB hard disks to your virtual machine. Configure one Stratis volume with the name myvol on top of these hard drives and make sure the volume is mounted persistently and automatically while booting.
	
	- Write a shell script that meets the following requirements:
	
	- It should evaluate the first argument provided.
	
	- When no argument is provided, it should prompt the user for input.
	
	- The script should evaluate whether the argument provided exists as a file or a directory, or doesn't exist at all.
	
	- If the argument is a file, the script should give a long listing of the filename.
	
	- If the argument is a directory, the script should give a long listing of the directory properties.
	
	- If the argument provided doesn't exist as a file or directory, the script should prompt with "Argument doesn't exist," where the text argument needs to be replaced with the actual argument. Also, in this case, this script should stop immediately with exit code 6.
	
	- Find all files that have the SUID permission set and write the result to the file /tmp/suid.txt.
	
	- Create the user lisa. Ensure that she needs to reset her password every 30 days. Ensure that she is able to manage passwords for all users, but not the user root.
	
	- Ensure that user lisa has permissions to modify all files in the /etc directory, without changing user or group ownership.
	
	- On the primary hard disk, use all the remaining disk space for an LVM volume group. In this volume group, create a 2GiB logical volume to be used as swap space.
	
	- On your primary network interface, configure a secondary IP address of 10.0.0.10/24.
	
	- Practice the procedure to reset a root password, assuming you don't know the current root password.
	
	- Secure the SSH service, such that only user lisa is allowed to log in.
	
	- Make sure that after a system restart, the system by default boots a graphical environment. (Even if it is doing this already by default, type the command again so that it is in your Bash history.)
	
	- Configure Bash history such that the last 2500 commands used are written to the history file.
	
	- Install the vsftpd service. Ensure that it is started automatically after a reboot, and configure it such that anonymous users are able to upload files.
	
	- Configure your system to use PHP version 7.1 as the default version.
	
	- Add a new disk to your virtual machine. On this disk, create a VDO volume with a virtual size of 1TiB.



# Odpowiedzi
[Spis treści](#spis-treści)

1. [Oreilly odpowiedzi](#Oreilly---odpowiedzi)
	1. [Exam A](#Exam-A---odpowiedzi)  
	2. [Exam B](#Exam-B---odpowiedzi)  
	3. [Exam C](#Exam-C---odpowiedzi)  
	4. [Exam D](#Exam-D---odpowiedzi)  
2. [vander odpowiedzi](#vander---odpowiedzi)
	1. [RHCSA vander 1](#vander-Exam-1---odpowiedzi)
	2. [RHCSA vander 2](#vander-Exam-2---odpowiedzi)


# Oreilly - odpowiedzi
[Spis treści](#spis-treści)

#### Moje odpowiedzi
1. Create user student with password password, and user root with password password.
```
useradd student 
useradd root

passwd stundent 
passwd root
```
6. 
```setfacl -m g:operations:r-x /groups/livingopensource```

## Exam A - odpowiedzi
[Spis treści](#spis-treści)



## Exam B - odpowiedzi
[Spis treści](#spis-treści)

## Exam C - odpowiedzi
[Spis treści](#spis-treści)

## Exam D - odpowiedzi
[Spis treści](#spis-treści)



# vander - odpowiedzi
[Spis treści](#spis-treści)

## vander Exam 1 - odpowiedzi
[Spis treści](#spis-treści)

3. Dodawanie użytkowników

- and make sure they get a home directory in ```/home/users```. (This means that, for instance, bill has ```/home/users/bill``` as his home directory.)
```
vim /etc/defaults/useradd 
HOME=/home/users
```

- Create four users: ```bill, bob, betty, and belinda```. 
```
useradd "$username"
```

- Set their **passwords to expire** after ```120 days``` 
```
# Ustawienie czasu ważności hasła, wygaśnie za 120 dni
sudo chage -M 120 "$username
```




## vander Exam 2 - odpowiedzi
[Spis treści](#spis-treści)




## Restart hasła roota

### #TODO - dodać swój opis
[Stronka objaśniająca](https://linuxconfig.org/redhat-8-recover-root-password)

## Zmiana adresu sieci 

## Ustawienie hostname 

## Stworzenie niestandardowego użytkownika ?

## Włączenie SELinux

## Nadanie kontekstu do pliku SELinux

[# Spis treści](#Spis-treści)