CREATE TABLE T_ESP_Temp_Humedad(
		idTempHumedad INT NOT NULL AUTO_INCREMENT UNIQUE,
		temperatura FLOAT(4,2) NOT NULL,
		humedad FLOAT(4,2) NOT NULL,
		idNode INT NOT NULL,
		horaFecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
		INDEX node_index (idNode),
		FOREIGN KEY (idNode) 
		REFERENCES T_ESP_Node(idNode)
		ON DELETE CASCADE
)