import React, { useState } from 'react';
import {
  Dimensions,
  PixelRatio,
  StyleSheet,
  // Dimensions,
} from 'react-native';
import * as DocumentPicker from 'expo-document-picker';
// import { DocumentPicker } from 'expo';
import { View } from 'react-native';
import {
  Box,
  Button,
  HStack,
  Icon,
  Image,
  Input,
  Link,
  ShareIcon,
  Text,
  VStack,
} from 'native-base';
import icon from './../../assets/favicon.png';
import { EvilIcons, MaterialIcons } from '@expo/vector-icons';
import { sendNewCommunication } from './NewCommunication.service';

const deviceHeigth = Dimensions.get('window').height;
const deviceWidth = Dimensions.get('window').width;

const NewCommunication = ({ navigation }) => {
  const [messageTitle, setMessageTitle] = useState('');
  const [messageDescription, setMessageDescription] = useState('');
  const [aubilousCSV, setAubilousCSV] = useState({});

  const pickDocument = async () => {
    let result = await DocumentPicker.getDocumentAsync({ type: ['text/csv'] });
    setAubilousCSV(result);
  };

  const communicate = () => {
    sendNewCommunication({
      title: messageTitle,
      text: messageDescription,
      file: aubilousCSV.uri,
    });
    alert('Comunicado enviado!');
  };

  return (
    <Box
      py={4}
      style={styles.container}
      m={10}
      borderWidth={1}
      borderColor={'gray.200'}
    >
      <Box
        height={'90%'}
        width={deviceWidth * 0.8}
        maxWidth={'95%'}
        alignSelf="center"
      >
        <Input
          alignSelf={'center'}
          color={'gray.600'}
          width={'100%'}
          mb={'3.5'}
          value={messageTitle}
          onChangeText={setMessageTitle}
          placeholder={'Título'}
          style={styles.input}
        />
        <Input
          multiline
          alignSelf={'center'}
          minHeight={'60%'}
          color={'gray.600'}
          width={'100%'}
          mb={'3.5'}
          value={messageDescription}
          onChangeText={setMessageDescription}
          placeholder={'Mensagem'}
          style={styles.input}
        />
        <Button
          onPress={pickDocument}
          bgColor="secondary.500"
          alignSelf={'flex-start'}
          endIcon={
            <Icon
              size={'md'}
              color="white"
              name="upload-file"
              as={MaterialIcons}
            />
          }
        >
          {aubilousCSV.name
            ? aubilousCSV.name
            : 'Escolher lista de Aubilous (CSV)'}
        </Button>
        <Link
          isExternal
          href="https://docs.google.com/spreadsheets/d/1siqc7AYY2G1XzmfvOYbaTZiMBksEoEkwGUstZwiF5Is/edit?usp=share_link"
        >
          Baixar modelo CSV
        </Link>
      </Box>
      <HStack
        space={2}
        height={'10%'}
        width={deviceWidth * 0.8}
        maxWidth={'95%'}
        alignSelf="center"
        justifyContent={'flex-end'}
      >
        <Button
          variant="outline"
          alignSelf={'flex-end'}
          color="primary.200"
          borderColor={'primary.200'}
          endIcon={
            <Icon
              size={'md'}
              color="primary.200"
              name="disabled-by-default"
              as={MaterialIcons}
            />
          }
          onPress={() => navigation.navigate('Communications')}
        >
          Cancelar
        </Button>
        <Button
          alignSelf={'flex-end'}
          bgColor="primary.200"
          endIcon={
            <Icon size={'md'} color="white" name="send" as={MaterialIcons} />
          }
          onPress={communicate}
        >
          Enviar Comunicado
        </Button>
      </HStack>
    </Box>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#f4f4f4',
    // justifyContent: 'center',
  },
  input: {
    width: 200,
    // height: 44,
  },
});

export default NewCommunication;
