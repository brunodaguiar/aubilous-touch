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
import { getCommunications } from './Communications.service';

const deviceWidth = Dimensions.get('window').width;

const Communications = ({ navigation }) => {
  const [lastCommunications, setLastCommunications] = useState([]);

  //useEffect(() => {}, [username, password]);

  useEffect(() => {
    const result = getCommunications(setLastCommunications);
  },[])

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
