### Server Setup:

**Update Kafka**

```
vi config/server.properties
```

```
advertised.listeners=PLAINTEXT://PUBLIC_IP:9092
log.dirs=/var/log/kafka
```

**Update ZooKeeper**

```
vi config/zookeeper.properties
```

```
dataDir=/var/log/zookeeper
```

### Create daemons:

**ZooKeeper**

```
sudo vi /etc/systemd/system/zookeeper.service
```

```
[Unit]
Description=Apache ZooKeeper Server
Requires=network.target remote-fs.target
After=network.target remote-fs.target

[Service]
Type=simple
User=root
ExecStart=/root/kafka/bin/zookeeper-server-start.sh /root/kafka/config/zookeeper.properties
ExecStop=/root/kafka/bin/zoookeeper-server-stop.sh
Restart=on-failure

[Install]
WantedBy=multi-user.target
```

**Kafka**

```
sudo vi /etc/systemd/system/kafka.service
```

```
[Unit]
Description=Apache Kafka Server
Requires=network.target remote-fs.target
After=network.target remote-fs.target zookeeper.service

[Service]
Type=simple
User=root
ExecStart=/root/kafka/bin/kafka-server-start.sh /root/kafka/config/server.properties
ExecStop=/root/kafka/bin/kafka-server-stop.sh
Restart=on-failure

[Install]
WantedBy=multi-user.target
```
