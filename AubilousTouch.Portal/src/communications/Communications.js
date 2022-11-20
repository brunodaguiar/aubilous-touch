import React, { useState } from 'react';
import { useEffect } from 'react';
import {
  Avatar,
  Badge,
  Box,
  Fab,
  FlatList,
  HStack,
  Icon,
  Image,
  Spacer,
  Text,
  VStack,
} from 'native-base';
import {
  Alert,
  Button,
  View,
  ImageBackground,
  StyleSheet,
  Dimensions,
} from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';

const deviceWidth = Dimensions.get('window').width;

const Communications = ({ navigation }) => {
  const { username, setUsername } = useState('');
  const { password, setPassword } = useState('');

  const lastCommunications = [
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
      deliveredPercentage: 82,
      date: '2022-11-19T00:21:03.066Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      deliveredPercentage: 98,
      date: '2022-05-01T00:21:40.694Z',
    },
    {
      title: 'Titulo 2',
      description:
        'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
      image:
        'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
      deliveredPercentage: 59,
      date: '2022-11-19T00:21:27.694Z',
    },
  ];

  useEffect(() => {}, [username, password]);

  return (
    <View style={styles.container}>
      <FlatList
        renderItem={({ item }) => (
          <Box
            backgroundColor={'white'}
            width={deviceWidth * 0.9}
            _dark={{
              borderColor: 'muted.50',
            }}
            borderRadius="lg"
            my="2"
            mx="3"
          >
            <VStack>
              <Box style={{ flex: 1 }} minHeight="150px">
                <ImageBackground
                  style={{ flex: 1, justifyContent: 'center' }}
                  source={{ uri: item.image }}
                  alt={item.image}
                  resizeMode="cover"
                >
                  <Box style={{ flex: 1 }}>
                    <Box
                      flex={1}
                      backgroundColor={
                        item.deliveredPercentage < 60
                          ? 'yellow.200'
                          : 'success.600'
                      }
                      borderRadius="md"
                      p={1}
                      top={5}
                      right={5}
                      position="absolute"
                    >
                      <Text mx={1}>{item.deliveredPercentage}%</Text>
                    </Box>
                  </Box>
                </ImageBackground>
              </Box>
              <HStack>
                <VStack>
                  <Text
                    _dark={{
                      color: 'warmGray.50',
                    }}
                    my="0.5"
                    ml="3.5"
                    fontSize="lg"
                    color="coolGray.700"
                    fontWeight={'semibold'}
                  >
                    {item.title}
                  </Text>
                  <Text
                    noOfLines={1}
                    color="coolGray.600"
                    maxWidth={'65%'}
                    ml="3.5"
                    mb="2.5"
                    _dark={{
                      color: 'warmGray.200',
                    }}
                  >
                    {item.description}
                  </Text>
                </VStack>
              </HStack>
            </VStack>
          </Box>
        )}
        data={lastCommunications}
        maxWidth={'95%'}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#ecf0f1',
  },
  input: {
    width: 200,
    height: 44,
    padding: 10,
    borderWidth: 1,
    borderColor: 'black',
    marginBottom: 10,
  },
});

export default Communications;
