--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 02.05.2023 9:48:25
-- Версия сервера: 5.5.28
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

--
-- Установка базы данных по умолчанию
--
USE gallery;

--
-- Удалить таблицу `admin`
--
DROP TABLE IF EXISTS admin;

--
-- Удалить таблицу `crosscreatorpaint`
--
DROP TABLE IF EXISTS crosscreatorpaint;

--
-- Удалить таблицу `creator`
--
DROP TABLE IF EXISTS creator;

--
-- Удалить таблицу `paint`
--
DROP TABLE IF EXISTS paint;

--
-- Удалить таблицу `genre`
--
DROP TABLE IF EXISTS genre;

--
-- Удалить таблицу `time`
--
DROP TABLE IF EXISTS time;

--
-- Установка базы данных по умолчанию
--
USE gallery;

--
-- Создать таблицу `time`
--
CREATE TABLE time (
  id int(11) NOT NULL AUTO_INCREMENT,
  time varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 6,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `genre`
--
CREATE TABLE genre (
  id int(11) NOT NULL AUTO_INCREMENT,
  genre varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 6,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `paint`
--
CREATE TABLE paint (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  description varchar(255) DEFAULT NULL,
  photoPaint varchar(255) DEFAULT NULL,
  genre int(11) DEFAULT NULL,
  time int(11) DEFAULT NULL,
  dateOfCreate int(11) DEFAULT NULL,
  material varchar(255) DEFAULT NULL,
  location varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 15,
AVG_ROW_LENGTH = 1489,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE paint
ADD CONSTRAINT FK_paint_time FOREIGN KEY (time)
REFERENCES time (id);

--
-- Создать внешний ключ
--
ALTER TABLE paint
ADD CONSTRAINT FK_paint_genre FOREIGN KEY (genre)
REFERENCES genre (id);

--
-- Создать таблицу `creator`
--
CREATE TABLE creator (
  id int(11) NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  genre int(11) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 13,
AVG_ROW_LENGTH = 1638,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE creator
ADD CONSTRAINT FK_creator_genre FOREIGN KEY (genre)
REFERENCES genre (id);

--
-- Создать таблицу `crosscreatorpaint`
--
CREATE TABLE crosscreatorpaint (
  idCreator int(11) NOT NULL,
  idPaint int(11) NOT NULL,
  id int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 13,
AVG_ROW_LENGTH = 1489,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE crosscreatorpaint
ADD CONSTRAINT FK_crosscreatorpaint_paint_id FOREIGN KEY (idPaint)
REFERENCES paint (id) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Создать внешний ключ
--
ALTER TABLE crosscreatorpaint
ADD CONSTRAINT FK_crosscreatorpaint_creator_id FOREIGN KEY (idCreator)
REFERENCES creator (id) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Создать таблицу `admin`
--
CREATE TABLE admin (
  id int(11) NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  lastname varchar(255) DEFAULT NULL,
  patronymic varchar(255) DEFAULT NULL,
  login varchar(255) NOT NULL DEFAULT '',
  password varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 2,
AVG_ROW_LENGTH = 16384,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

-- 
-- Вывод данных для таблицы time
--
INSERT INTO time VALUES
(1, 'Ренессеанс'),
(2, 'Импрессионизм'),
(3, 'Символизм'),
(4, 'Реализм'),
(5, 'Наше время');

-- 
-- Вывод данных для таблицы genre
--
INSERT INTO genre VALUES
(1, 'Живопись'),
(3, 'Изобразительное искусство'),
(4, 'Портрет');

-- 
-- Вывод данных для таблицы paint
--
INSERT INTO paint VALUES
(1, 'Мона Лиза', 'Художник: Леонардо да Винчи\r\nДата создания: 1503 год\r\nЖанр: Портрет\r\nПериод: Эпоха Возрождения\r\nМатериал: Масляные краски\r\nМестоположение: Лувр (с 1797 года)\r\n', '~\\..\\images/monalisa.jpg', 4, 1, 1503, 'Маслянные краски', 'Лувр'),
(2, 'Сотворение Адама', 'Художник: Микеланджело\r\nДата создание: 1511 год\r\nЖанр: Историческая живопись\r\nПериод: Эпоха Возрождения\r\nМестоположение: Сикстинская капелла\r\nМатериалы: Краска, штукатурка\r\n', '~\\..\\images/adam.jpg', 1, 1, 1511, 'Краски, штукатурка', 'Сикстинская капелла'),
(3, 'Витязь на распутье', 'Художник: Васнецов Виктор Михайлович\r\nДата создания: 1882 год\r\nЖанр: Мифологическая живопись\r\nПериод: Романтизм, Символизм\r\nМестоположение: Серпуховский историко-художественный музей\r\nМатериал: Масляные краски, холст', '~\\..\\images/vityaz.jpeg', 1, 3, 1882, 'Малянные краски', 'Серпуховский историко-художественный музей'),
(4, 'Мишки в сосновом бору', 'Художник: Шишкин Иван Иванович и Константин Аполлонович Савицкий\r\nДата создания: 1889 год\r\nЖанр: Пейзаж, изобразительное искусство\r\nПериод: Символизм\r\nМестоположение: Государственная Третьяковская галерея\r\nМатериал: Масляные краски', '~\\..\\images/bears.jpg', 3, 3, 1889, 'Масляные краски', 'Государственная Третьяковская галерея'),
(5, 'Звёздная ночь', 'Художник: Винсент Ван Гог\r\nДата создания: 1889 год\r\nЖанр: Изобразительное искусство\r\nПериод: Постимпрессионизм\r\nМестоположение: Нью-Йоркский музей современного искусства\r\nМатериал: Масляные краски\r\n', '~\\..\\images/star.jpg', 3, 2, 1889, 'Масляные краски', 'Нью-Йоркский музей современного искусства'),
(6, 'Восходящее солнце', 'Художник: Клод Моне\r\nДата создания: 1872 год\r\nЖанр: Пейзаж, Марина\r\nПериод: Импрессионизм\r\nМестоположение: Музей Мармоттан-Моне\r\nМатериал: Масляные краски', '~\\..\\images/sun.jpg', 3, 2, 1872, 'Масляные краски', 'Музей Мармоттан-Моне'),
(7, 'Последний день. Помпеи', 'Художник: Брюллов Карл Павлович\r\nДата создания: 1830-1833 г.г.\r\nЖанр: Историческая живопись\r\nПериод: Реализм\r\nМестоположение: Русский музей, Михайловский дворец\r\nМатериал: Масляные краски, холст', '~\\..\\images/pompei.jpg', 1, 4, 1833, 'Холст, маслянные краски', 'Русский музей'),
(8, 'Бурлаки на Волге', 'Художник: Репин Илья Ефимович\r\nДата создания: 1870-1873 г.г.\r\nЖанр: Историческая живопись\r\nПериод: Реализм\r\nМестоположение: Русский музей\r\nМатериал: Масляные краски, холст', '~\\..\\images/burlaki.png', 1, 4, 1873, 'Холст, маслянные краски', 'Русский музей'),
(9, 'Сикстинская Мадонна', 'Художник: Рафаель Санти\r\nДата создания: 1512 год\r\nЖанр: Христианское искусство\r\nПериод: Эпоха Возрождения\r\nМестположение: Галерея старых мастеров в Дрездене\r\nМатериал: Масляные краски, холст ', '~\\..\\images/sikstinskaya-madonna.jpeg', 3, 1, 1512, 'Холст, маслянные краски', 'Галерея старых мастеров в Дрездене'),
(10, 'Завтрак гребцов', 'Художник: Пьер Огюст Ренуар\r\nДата создания: 1881 год\r\nЖанр: Изобразительное искусство\r\nПериод: Импрессионизм\r\nМестоположение: Собрание Филилипс\r\nМатериал: Масляные краски', '~\\..\\images/breakfast.jpg', 3, 2, 1881, 'Масляные краски', 'Собрание Филлипс'),
(11, 'Полигимния', 'цкеоекоеко', '~\\..\\images/poligimnia.jpg', 3, 5, 2013, 'Холст, акрил, коллаж', 'Государственная Третьяковская галерея');

-- 
-- Вывод данных для таблицы creator
--
INSERT INTO creator VALUES
(1, 'Леонардо да Винчи', 4),
(2, 'Микеланджело', 1),
(3, 'Васнецов В.М.', 1),
(4, 'Шишкин И.И.', 3),
(5, 'Винсент Ван Гог', 3),
(6, 'Клод Моне', 3),
(7, 'Брюллов К.П.', 1),
(8, 'Репин И.Е.', 1),
(9, 'Рафаель Санти', 1),
(10, 'Огюст Ренуар', 3),
(11, 'Валерий Николаевич Кошляков', 3),
(12, 'пп', NULL);

-- 
-- Вывод данных для таблицы crosscreatorpaint
--
INSERT INTO crosscreatorpaint VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5),
(6, 6, 6),
(7, 7, 7),
(8, 8, 8),
(9, 9, 9),
(10, 10, 10),
(11, 11, 11);

-- 
-- Вывод данных для таблицы admin
--
INSERT INTO admin VALUES
(1, 'Владимир', 'Пункин', 'Владимирович', '1991', '1991');

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;