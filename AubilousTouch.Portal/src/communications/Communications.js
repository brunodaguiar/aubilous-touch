import React, { useState } from 'react';
import { useEffect } from 'react';
import {
  Avatar,
  Badge,
  Box,
  Center,
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
  Platform,
  PixelRatio,
} from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';
import { getCommunications } from './Communications.service';

const deviceWidth = Dimensions.get('window').width;

const Communications = () => {
   const [lastCommunications, setLastCommunications] = useState([]);

   useEffect(() => {
     const result = getCommunications(setLastCommunications);
   }, []);
/*
  const lastCommunications = [
    {
      message: {
        subject: 'Titulo 2',
        body: 'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
        image:
          'https://fujifilm-x.com/wp-content/uploads/2021/01/gfx100s_sample_04_thum-1.jpg',
        deliveredPercentage: 82,
        date: '2022-11-19T00:21:03.066Z',
      },
    },
    {
      message: {
        subject: 'Titulo 2',
        body: 'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
        image:
          'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
        deliveredPercentage: 98,
        date: '2022-05-01T00:21:40.694Z',
      },
    },
    {
      message: {
        subject: 'Titulo 2',
        body: 'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
        image:
          'https://images.unsplash.com/photo-1579353977828-2a4eab540b9a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8c2FtcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
        deliveredPercentage: 98,
        date: '2022-05-01T00:21:40.694Z',
      },
    },
    {
      message: {
        subject: 'Titulo 2',
        body: 'description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 description 2 ',
        image:
          'https://cdn.pixabay.com/photo/2019/07/30/18/26/surface-4373559__340.jpg',
        deliveredPercentage: 59,
        date: '2022-11-19T00:21:27.694Z',
      },
    },
  ];
*/
  return (
    <View style={styles.container}>
      <FlatList
        renderItem={({ item }) => (
          <Box
            backgroundColor={'white'}
            width={deviceWidth * 0.95}
            _dark={{
              borderColor: 'muted.50',
            }}
            borderRadius="md"
            my="2"
          >
            <VStack>
              <HStack>
                <Box flex={4}>
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
                    {item.message.subject}
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
                    {item.message.body}
                  </Text>
                </Box>
                <Box
                  bgColor="primary.600"
                  py={1}
                  px={2}
                  rounded="md"
                  height={'60%'}
                >
                  <Text mx={1} color="white" fontSize="xl">
                    {lastCommunications.statistics.find((param) => param.messageId === item.message.id).successRate }%{' '}
                    {Platform.OS === 'web' && 'entregue'}
                  </Text>
                </Box>
              </HStack>
            </VStack>
          </Box>
        )}
        data={lastCommunications.messages}
        maxWidth={'97%'}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 10,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#f4f4f4',
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
